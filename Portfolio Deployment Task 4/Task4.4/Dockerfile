# Use minimal Python 3.11 Alpine Linux base image (~50MB)
FROM python:3.11-alpine

WORKDIR /academic-cli

COPY task4.4.py .

# Unbuffered environment ensures interactive I/O displays instantly
ENV PYTHONUNBUFFERED=1

ENTRYPOINT ["python", "task4.4.py"]