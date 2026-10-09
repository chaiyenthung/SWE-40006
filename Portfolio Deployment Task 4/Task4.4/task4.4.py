import sys
import socket

# Standard university grade point scale (4.0 Scale)
GRADE_POINTS = {
    'A+': 4.0, 'A': 4.0, 'A-': 3.7,
    'B+': 3.3, 'B': 3.0, 'B-': 2.7,
    'C+': 2.3, 'C': 2.0, 'C-': 1.7,
    'D': 1.0,  'F': 0.0,
    # Also support Australian / Swinburne conventions
    'HD': 4.0, 'D': 3.0, 'C': 2.0, 'P': 1.0, 'N': 0.0
}

# Pre-populated sample units
courses = [
    {"code": "SWE40006", "name": "Software Deployment and Evolution", "credits": 4, "grade": "HD"},
    {"code": "COS10005", "name": "Web Development", "credits": 4, "grade": "D"},
    {"code": "BUS10015", "name": "Creative Mindset and Entrepreneurship", "credits": 3, "grade": "C"}
]

def print_header():
    cid = socket.gethostname()
    print("=" * 68)
    print("   STUDENT ACADEMIC TRANSCRIPT & CGPA ANALYZER (CLI)")
    print(f"   Execution Environment: Docker Container (ID: {cid})")
    print("=" * 68)

def display_transcript():
    if not courses:
        print("\n[!] No courses recorded yet.")
        return
        
    print("\n" + "-" * 68)
    print(f"{'Code':<12} {'Unit Name':<26} {'Credits':<10} {'Grade':<8} {'Points':<6}")
    print("-" * 68)
    for c in courses:
        pts = GRADE_POINTS.get(c['grade'].upper(), 0.0)
        print(f"{c['code']:<12} {c['name']:<26} {c['credits']:<10} {c['grade']:<8} {pts:<6.1f}")
    print("-" * 68)

def calculate_gpa():
    if not courses:
        print("\n[!] Cannot calculate GPA. No courses entered.")
        return
        
    total_credits = sum(c['credits'] for c in courses)
    total_quality_points = sum(c['credits'] * GRADE_POINTS.get(c['grade'].upper(), 0.0) for c in courses)
    
    gpa = total_quality_points / total_credits if total_credits > 0 else 0.0
    
    # Determine Academic Standing
    if gpa >= 3.75:
        standing = "First Class / Dean's Commendation"
    elif gpa >= 3.00:
        standing = "Good Academic Standing (Distinction)"
    elif gpa >= 2.00:
        standing = "Satisfactory Standing"
    else:
        standing = "Academic Warning (Probation)"
        
    print("\n" + "=" * 48)
    print("            ACADEMIC PERFORMANCE SUMMARY")
    print("=" * 48)
    print(f" Total Completed Credits: {total_credits}")
    print(f" Total Quality Points:    {total_quality_points:.2f}")
    print(f" Cumulative GPA (CGPA):   {gpa:.2f} / 4.00")
    print(f" Academic Standing:       {standing}")
    print("=" * 48)

def add_course():
    print("\n--- Add New Course ---")
    code = input("Enter unit code (e.g. SWE30001): ").strip().upper()
    name = input("Enter unit title: ").strip()
    try:
        credits = int(input("Enter credit hours (e.g. 3 or 4): ").strip())
        if credits <= 0:
            print("[!] Credits must be greater than zero.")
            return
    except ValueError:
        print("[!] Invalid credit number format.")
        return
        
    grade = input("Enter grade achieved (A+, A, B+, B, C, D, F / HD, D, C, P): ").strip().upper()
    if grade not in GRADE_POINTS:
        print(f"[!] Unrecognized grade '{grade}'. Supported grades: {list(GRADE_POINTS.keys())}")
        return
        
    courses.append({"code": code, "name": name, "credits": credits, "grade": grade})
    print(f"\n[+] Successfully added {code} to academic record.")

def main():
    print_header()
    while True:
        print("\n[MAIN MENU]")
        print("1. View Current Academic Transcript")
        print("2. Add New Completed Course")
        print("3. Calculate CGPA & Academic Standing")
        print("4. Clear All Records")
        print("5. Exit Application")
        
        choice = input("\nEnter selection (1-5): ").strip()
        
        if choice == '1':
            display_transcript()
        elif choice == '2':
            add_course()
        elif choice == '3':
            calculate_gpa()
        elif choice == '4':
            confirm = input("Are you sure you want to clear all records? (y/n): ").strip().lower()
            if confirm == 'y':
                courses.clear()
                print("\n[*] All academic records cleared.")
        elif choice == '5':
            print("\nShutting down GPA Analyzer. Container process exiting cleanly.")
            sys.exit(0)
        else:
            print("[!] Invalid choice. Please enter a number between 1 and 5.")

if __name__ == '__main__':
    main()