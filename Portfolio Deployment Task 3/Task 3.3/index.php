<?php
session_start();

$studentID = "105025228";
$serverSoftware = $_SERVER['SERVER_SOFTWARE'] ?? 'Azure Linux Web App';
$phpVersion = phpversion();
$requestTime = date("d M Y - H:i:s T");

if (!isset($_SESSION['tasks'])) {
    $_SESSION['tasks'] = [
        ['id' => 1, 'title' => 'Install PHP extensions in VS Code', 'status' => 'Completed'],
        ['id' => 2, 'title' => 'Deploy PHP App Service to Azure Linux Container', 'status' => 'In Progress'],
        ['id' => 3, 'title' => 'Verify Live PHP Deployment for HD Grade', 'status' => 'Pending']
    ];
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $action = $_POST['action'] ?? '';

    // Add Task
    if ($action === 'add') {
        $title = trim($_POST['taskTitle'] ?? '');
        if (!empty($title)) {
            $maxId = 0;
            foreach ($_SESSION['tasks'] as $t) {
                if ($t['id'] > $maxId) $maxId = $t['id'];
            }
            $_SESSION['tasks'][] = [
                'id' => $maxId + 1,
                'title' => htmlspecialchars($title),
                'status' => 'Pending'
            ];
        }
    }

    // Change Status
    if ($action === 'toggle') {
        $id = intval($_POST['id'] ?? 0);
        foreach ($_SESSION['tasks'] as &$t) {
            if ($t['id'] === $id) {
                if ($t['status'] === 'Pending') $t['status'] = 'In Progress';
                elseif ($t['status'] === 'In Progress') $t['status'] = 'Completed';
                else $t['status'] = 'Pending';
                break;
            }
        }
    }

    // Delete Task
    if ($action === 'delete') {
        $id = intval($_POST['id'] ?? 0);
        $_SESSION['tasks'] = array_filter($_SESSION['tasks'], function($t) use ($id) {
            return $t['id'] !== $id;
        });
        $_SESSION['tasks'] = array_values($_SESSION['tasks']); // re-index
    }

    header("Location: index.php");
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SWE40006 - PHP To-Do App (Task 3.3 HD)</title>
    <style>
        body {
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Arial, sans-serif;
            background-color: #f4f6f9;
            margin: 0;
            padding: 30px;
            color: #1e293b;
        }
        .container {
            max-width: 900px;
            margin: 0 auto;
        }
        .header-card {
            background: linear-gradient(135deg, #cec8ef, #b19cd9);
            color: white;
            padding: 24px 30px;
            border-radius: 12px;
            box-shadow: 0 4px 15px rgba(99, 102, 241, 0.25);
            margin-bottom: 25px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            flex-wrap: wrap;
        }
        .header-card h2 { margin: 0 0 6px 0; font-size: 24px; font-weight: 600; }
        .header-card p { margin: 0; font-size: 14px; opacity: 0.95; }
        .diagnostics-bar {
            background: white;
            padding: 14px 20px;
            border-radius: 10px;
            border: 1px solid #e2e8f0;
            margin-bottom: 25px;
            display: flex;
            justify-content: space-between;
            font-size: 13px;
            color: #475569;
            flex-wrap: wrap;
            gap: 10px;
        }
        .grid {
            display: grid;
            grid-template-columns: 320px 1fr;
            gap: 20px;
        }
        @media(max-width: 768px) {
            .grid { grid-template-columns: 1fr; }
        }
        .card {
            background: white;
            padding: 22px;
            border-radius: 12px;
            border: 1px solid #e2e8f0;
            box-shadow: 0 2px 6px rgba(0,0,0,0.03);
        }
        .card h4 {
            margin: 0 0 16px 0;
            font-size: 16px;
            color: #1e293b;
            font-weight: 600;
        }
        input[type="text"] {
            width: 100%;
            padding: 10px 12px;
            border-radius: 8px;
            border: 1px solid #cbd5e1;
            font-size: 14px;
            box-sizing: border-box;
            margin-bottom: 15px;
        }
        .btn-add {
            background-color: #b19cd9;
            color: white;
            border: none;
            padding: 10px;
            width: 100%;
            border-radius: 8px;
            font-weight: 600;
            cursor: pointer;
            transition: background 0.2s;
        }
        .btn-add:hover { background-color: #4338ca; }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th {
            text-align: left;
            font-size: 12px;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            color: #64748b;
            padding: 10px 12px;
            border-bottom: 2px solid #f1f5f9;
        }
        td {
            padding: 12px;
            border-bottom: 1px solid #f8fafc;
            vertical-align: middle;
        }
        .status-pill {
            display: inline-block;
            padding: 4px 10px;
            border-radius: 20px;
            font-size: 11px;
            font-weight: 600;
        }
        .status-Completed { background: #dcfce7; color: #15803d; }
        .status-In-Progress { background: #fef3c7; color: #b45309; }
        .status-Pending { background: #f1f5f9; color: #475569; }
        .task-done { text-decoration: line-through; color: #94a3b8; }
        .btn-cycle {
            background: #f8fafc;
            border: 1px solid #cbd5e1;
            color: #334155;
            padding: 5px 10px;
            border-radius: 6px;
            font-size: 12px;
            cursor: pointer;
        }
        .btn-cycle:hover { background: #4f46e5; color: white; border-color: #4f46e5; }
        .btn-delete {
            background: #fee2e2;
            border: 1px solid #fecaca;
            color: #dc2626;
            width: 28px;
            height: 28px;
            border-radius: 50%;
            cursor: pointer;
            font-size: 12px;
            line-height: 24px;
            text-align: center;
            padding: 0;
            margin-left: 4px;
        }
        .btn-delete:hover { background: #dc2626; color: white; }
    </style>
</head>
<body>
<div class="container">
    <!-- Header -->
    <div class="header-card">
        <div>
            <h2>SWE40006 — PHP Task Manager</h2>
            <p>Task 3.3 High Distinction | Student ID: <strong><?php echo $studentID; ?></strong></p>
        </div>
        <div style="text-align: right; font-size: 13px;">
            <span>🐘 PHP <?php echo htmlspecialchars($phpVersion); ?></span><br>
            <span>☁️ Azure Linux App Service</span>
        </div>
    </div>

    <!-- Server Diagnostics Bar -->
    <div class="diagnostics-bar">
        <span><strong>Host:</strong> <?php echo htmlspecialchars(gethostname()); ?></span>
        <span><strong>Web Server:</strong> <?php echo htmlspecialchars($serverSoftware); ?></span>
        <span><strong>Server Time:</strong> <?php echo htmlspecialchars($requestTime); ?></span>
    </div>

    <!-- Content Grid -->
    <div class="grid">
        <!-- Add Task Form -->
        <div class="card">
            <h4>Add New To-Do</h4>
            <form method="POST" action="index.php">
                <input type="hidden" name="action" value="add">
                <label style="font-size: 13px; color: #475569; display: block; margin-bottom: 6px;">Task Description</label>
                <input type="text" name="taskTitle" placeholder="e.g. Audit Azure resource logs" required>
                <button type="submit" class="btn-add">+ Add Task (PHP POST)</button>
            </form>
        </div>

        <!-- Task Table -->
        <div class="card">
            <h4>Active PHP Task Items (<?php echo count($_SESSION['tasks']); ?>)</h4>
            <?php if (empty($_SESSION['tasks'])): ?>
                <p style="color: #94a3b8; text-align: center; padding: 25px 0;">No tasks found. Create one using the form on the left!</p>
            <?php else: ?>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 8%;">#</th>
                            <th>Description</th>
                            <th style="width: 22%;">Status</th>
                            <th style="width: 25%; text-align: right;">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php foreach ($_SESSION['tasks'] as $task): 
                            $classStatus = str_replace(' ', '-', $task['status']);
                        ?>
                            <tr>
                                <td style="color: #94a3b8; font-weight: 500;"><?php echo $task['id']; ?></td>
                                <td class="<?php echo ($task['status'] === 'Completed') ? 'task-done' : ''; ?>">
                                    <strong><?php echo htmlspecialchars($task['title']); ?></strong>
                                </td>
                                <td>
                                    <span class="status-pill status-<?php echo $classStatus; ?>">
                                        <?php echo htmlspecialchars($task['status']); ?>
                                    </span>
                                </td>
                                <td style="text-align: right; white-space: nowrap;">
                                    <!-- Cycle Status -->
                                    <form method="POST" action="index.php" style="display: inline;">
                                        <input type="hidden" name="action" value="toggle">
                                        <input type="hidden" name="id" value="<?php echo $task['id']; ?>">
                                        <button type="submit" class="btn-cycle" title="Cycle Status">⟳ Change Status</button>
                                    </form>
                                    <!-- Delete -->
                                    <form method="POST" action="index.php" style="display: inline;" onsubmit="return confirm('Delete this task?');">
                                        <input type="hidden" name="action" value="delete">
                                        <input type="hidden" name="id" value="<?php echo $task['id']; ?>">
                                        <button type="submit" class="btn-delete" title="Delete Task">✕</button>
                                    </form>
                                </td>
                            </tr>
                        <?php endforeach; ?>
                    </tbody>
                </table>
            <?php endif; ?>
        </div>
    </div>
</div>
</body>
</html>