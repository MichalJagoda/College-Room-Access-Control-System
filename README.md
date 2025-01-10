# College Room Access Control System

## Project Overview
This College Room Access Control System is a prototype software application designed to secure and manage access to college facilities 
using a swipe card system. It is specialised to ensure efficient and secure access for all users (students, staff, visitors, cleaners, 
managers, security and emergency responders) while demonstrating detailed logging and management capabilities.

## Features
- **User Authentication**: Secure login for authorised users.
- **Room Access Management**: Room access is configured based on room types and user roles.
- **Emergency Mode**: Emergency mode to allow emergency responders to access while restricting other users.
- **Access Logs**: Daily logs are generated automatically for all access attempts, successful and failed.
- **User and Role Management**: Users and roles are able to be added, updated, or removed.
- **Room Management**: Rooma can be added, updated, or removed and the state of each room may be switched between NORMAL and EMERGENCY.

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/MichalJagoda/College-Room-Access-Control-System.git
   ```
2. **Open in Visual Studio**:
   - Open the `College Room Access Control System.sln` file in Visual Studio.
3. **Build the Project**:
   - Use the `Build` option in Visual Studio to compile the application.
4. **Run the Application**:
   - Launch the application using the `Start` button in Visual Studio.

## Usage
1. **Launch Application**:
   - Run form Visual Studio or double-click the executable file.
2. **Manage Users**:
   - Campus users may be added, updated, or removed and roles may be assigned.
3. **Manage Rooms**:
   - Rooms may be added, updated, or removed and their states set to NORMAL or EMERGENCY.
4. **Simulate Swipe**:
   - A swipe will simulate a user attempting to access a room and a log entry will be generated.
5. **View Logs**:
   - Room usage and security events can be monitored via the daily log file.

## Stakeholders
- **Students**: Use their swipe cards to access authorised areas e.g. teaching rooms and lecture halls.
- **Faculty Members**: Can gain secure access to teaching rooms, lecture halls, and staff rooms.
- **College Management**: Room access activities can be monitored and audited for safety and efficiency.
- **IT Administrators**: Configure and manage the swipe card system and all of its users.
- **Emergency Responders**: Critical access is ensured during emergencies.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET Framework
- **Development Environment**: Microsoft Visual Studio

## Repository Structure
```
College-Room-Access-Control-System/
  - README.md
  - .gitignore
  - College Room Access Control System.sln
  - App.config
  - Form1.cs
  - Form1.Designer.cs
  - Program.cs
  - Properties/
  - bin/
  - obj/
  - ID_Card_List.txt
  - room_access_log_{date}.txt
```

## Future Enhancements
- **Advanced Role Management**: Implement additional role-based permissions.
- **Biometric Authentication**: Add support for fingerprint or facial recognition.
- **Cloud Integration**: Store access logs and user data securely in the cloud.

## Contact Information
For further assistance or queries, please contact:
- **Author**: Michal Jagoda
- **Email**: [Your Email Address Here]
- **GitHub**: [GitHub Profile Link Here]

---
Thank you for using the College Room Access Control System. Your feedback is appreciated!

