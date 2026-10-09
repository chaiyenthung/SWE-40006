import sqlite3
import socket
import datetime
from flask import Flask, request, redirect, url_for, render_template_string

app = Flask(__name__)
DB_NAME = "expenses.db"

def init_db():
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("""
        CREATE TABLE IF NOT EXISTS expenses (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            title TEXT NOT NULL,
            amount REAL NOT NULL,
            category TEXT NOT NULL,
            date TEXT NOT NULL
        )
    """)
    # Insert initial sample data if empty
    cursor.execute("SELECT COUNT(*) FROM expenses")
    if cursor.fetchone()[0] == 0:
        sample_data = [
            ("Shopping", 65.50, "Food", "2026-10-01"),
            ("Apartment Rent", 850.00, "Rent", "2026-10-01"),
            ("Electricity Bill", 74.20, "Utilities", "2026-10-03"),
            ("Fuel Oil", 50.00, "Transport", "2026-10-05")
        ]
        cursor.executemany("INSERT INTO expenses (title, amount, category, date) VALUES (?, ?, ?, ?)", sample_data)
        conn.commit()
    conn.close()

HTML_TEMPLATE = """
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Task 4.3 - Personal Expense Tracker</title>
    <style>
        body { font-family: 'Segoe UI', Arial, sans-serif; background-color: #f4f6f9; margin: 0; padding: 30px; }
        .container { max-width: 900px; margin: auto; }
        .header { background: white; padding: 20px 30px; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.06); margin-bottom: 25px; display: flex; justify-content: space-between; align-items: center; }
        .header h1 { margin: 0; color: #1f2937; font-size: 24px; }
        .meta { color: #6b7280; font-size: 13px; text-align: right; }
        .summary-grid { display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 15px; margin-bottom: 25px; }
        .card { background: white; padding: 20px; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.06); }
        .card h3 { margin: 0 0 10px 0; font-size: 14px; color: #6b7280; text-transform: uppercase; }
        .card .value { font-size: 26px; font-weight: bold; color: #111827; }
        .card.total .value { color: #2563eb; }
        .form-section { background: white; padding: 25px; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.06); margin-bottom: 25px; }
        .form-section h2 { margin-top: 0; font-size: 18px; color: #374151; }
        .form-grid { display: grid; grid-template-columns: 2fr 1fr 1fr 1fr auto; gap: 10px; align-items: center; }
        input, select { padding: 10px; border: 1px solid #d1d5db; border-radius: 6px; font-size: 14px; }
        button.btn-add { background: #10b981; color: white; border: none; padding: 10px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; }
        button.btn-add:hover { background: #059669; }
        table { width: 100%; border-collapse: collapse; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.06); }
        th, td { padding: 14px 18px; text-align: left; }
        th { background-color: #f9fafb; font-size: 13px; text-transform: uppercase; color: #6b7280; border-bottom: 1px solid #e5e7eb; }
        tr:not(:last-child) td { border-bottom: 1px solid #f3f4f6; }
        .tag { display: inline-block; padding: 4px 10px; border-radius: 20px; font-size: 12px; font-weight: 600; }
        .tag-Food { background: #fee2e2; color: #991b1b; }
        .tag-Rent { background: #fef3c7; color: #92400e; }
        .tag-Utilities { background: #dbeafe; color: #1e40af; }
        .tag-Transport { background: #e0e7ff; color: #3730a3; }
        .tag-Other { background: #f3f4f6; color: #374151; }
        .btn-del { background: #ef4444; color: white; border: none; padding: 6px 12px; border-radius: 4px; cursor: pointer; font-size: 12px; }
        .btn-del:hover { background: #dc2626; }
    </style>
</head>
<body>
    <div class="container">
        <div class="header">
            <div>
                <h1>Personal Expense Tracker</h1>
                <small style="color: #6b7280;">Task 4.3 - Advanced CRUD Web Application</small>
            </div>
            <div class="meta">
                <strong>Container Host:</strong> {{ hostname }}<br>
                <strong>Server Time:</strong> {{ time }}
            </div>
        </div>

        <!-- Summary Cards -->
        <div class="summary-grid">
            <div class="card total">
                <h3>Total Expenses</h3>
                <div class="value">RM{{ "%.2f"|format(total_expense) }}</div>
            </div>
            {% for cat, amt in cat_totals.items() %}
            <div class="card">
                <h3>{{ cat }}</h3>
                <div class="value">RM{{ "%.2f"|format(amt) }}</div>
            </div>
            {% endfor %}
        </div>

        <!-- Expense Input Form -->
        <div class="form-section">
            <h2>Add New Expense</h2>
            <form method="POST" action="/add" class="form-grid">
                <input type="text" name="title" placeholder="Description (e.g. Lunch)" required>
                <input type="number" step="0.01" name="amount" placeholder="Amount (RM)" required>
                <select name="category" required>
                    <option value="Food">Food</option>
                    <option value="Rent">Rent</option>
                    <option value="Utilities">Utilities</option>
                    <option value="Transport">Transport</option>
                    <option value="Other">Other</option>
                </select>
                <input type="date" name="date" required value="{{ today }}">
                <button type="submit" class="btn-add">+ Add</button>
            </form>
        </div>

        <!-- Expense Table -->
        <table>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Description</th>
                    <th>Category</th>
                    <th>Amount</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {% for exp in expenses %}
                <tr>
                    <td>{{ exp[4] }}</td>
                    <td><strong>{{ exp[1] }}</strong></td>
                    <td><span class="tag tag-{{ exp[3] }}">{{ exp[3] }}</span></td>
                    <td>RM{{ "%.2f"|format(exp[2]) }}</td>
                    <td>
                        <form method="POST" action="/delete/{{ exp[0] }}" style="margin: 0;">
                            <button type="submit" class="btn-del" onclick="return confirm('Delete this record?');">Delete</button>
                        </form>
                    </td>
                </tr>
                {% else %}
                <tr>
                    <td colspan="5" style="text-align: center; color: #9ca3af; padding: 30px;">No expenses logged yet.</td>
                </tr>
                {% endfor %}
            </tbody>
        </table>
    </div>
</body>
</html>
"""

@app.route('/', methods=['GET'])
def index():
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("SELECT id, title, amount, category, date FROM expenses ORDER BY date DESC, id DESC")
    expenses = cursor.fetchall()
    
    total_expense = sum(row[2] for row in expenses)
    cat_totals = {}
    for row in expenses:
        cat_totals[row[3]] = cat_totals.get(row[3], 0.0) + row[2]
    conn.close()

    today = datetime.date.today().strftime("%Y-%m-%d")
    now_time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")

    return render_template_string(
        HTML_TEMPLATE,
        expenses=expenses,
        total_expense=total_expense,
        cat_totals=cat_totals,
        hostname=socket.gethostname(),
        time=now_time,
        today=today
    )

@app.route('/add', methods=['POST'])
def add_expense():
    title = request.form.get('title')
    amount = float(request.form.get('amount', 0))
    category = request.form.get('category')
    date = request.form.get('date')

    if title and amount > 0:
        conn = sqlite3.connect(DB_NAME)
        cursor = conn.cursor()
        cursor.execute("INSERT INTO expenses (title, amount, category, date) VALUES (?, ?, ?, ?)",
                       (title, amount, category, date))
        conn.commit()
        conn.close()

    return redirect(url_for('index'))

@app.route('/delete/<int:item_id>', methods=['POST'])
def delete_expense(item_id):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("DELETE FROM expenses WHERE id = ?", (item_id,))
    conn.commit()
    conn.close()
    return redirect(url_for('index'))

if __name__ == '__main__':
    init_db()
    # Run web server on port 8080
    app.run(host='0.0.0.0', port=8080)