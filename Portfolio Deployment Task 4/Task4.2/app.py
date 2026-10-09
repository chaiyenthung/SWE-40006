from flask import Flask
import socket
import datetime

app = Flask(__name__)

@app.route('/')
def hello_world():
    container_id = socket.gethostname()
    current_time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    return f"""
    <!DOCTYPE html>
    <html>
    <head>
        <title>Task 4.2 - Python Hello World Server</title>
        <style>
            body {{ font-family: "Times New Roman", Times, serif; text-align: center; margin-top: 60px; background-color: #f7f9fc; }}
            .card {{ background: white; padding: 30px; border-radius: 12px; display: inline-block; box-shadow: 0 4px 12px rgba(0,0,0,0.1); }}
            h1 {{ color: #0070f3; }}
            p {{ font-size: 16px; color: #555; }}
            code {{ background: #eee; padding: 3px 8px; border-radius: 4px; font-weight: bold; }}
        </style>
    </head>
    <body>
        <div class="card">
            <h1>Hello World from Python Web Server!</h1>
            <p><strong>Task 4.2:</strong> Credit Level Container Deployment</p>
            <p>Running inside Container ID: <code>{container_id}</code></p>
            <p>Server Time: <code>{current_time}</code></p>
        </div>
    </body>
    </html>
    """

if __name__ == '__main__':
    # Listen on all interfaces on port 5000
    app.run(host='0.0.0.0', port=5000)