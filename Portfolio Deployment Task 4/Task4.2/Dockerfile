# Add official Python runtime
FROM python:3.11-slim

# Set working directory
WORKDIR /app

# Copy dependencies and install
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Copy application source code
COPY app.py .

# Expose web server port
EXPOSE 5000

# Run the application
CMD ["python", "app.py"]
