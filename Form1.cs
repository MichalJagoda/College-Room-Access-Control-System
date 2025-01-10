using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;




namespace College_Room_Access_Control_System
{
    public partial class Form1 : Form
    {
        private List<User> Users = new List<User>();
        private List<Room> Rooms = new List<Room>();
        private string LogDirectory = @"Logs";
        private string UsersFile = @"ID_Card_List.txt";

        private const string UsersFilePath = "users.json";
        private const string RoomsFilePath = "rooms.json";


        public Form1()
        {
           InitializeComponent();
            LoadUsers();
            LoadRooms();

        }

        private void LoadUsers()
        {
            if (File.Exists(UsersFilePath))
            {
                var json = File.ReadAllText(UsersFilePath);
                Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            else
            {
                Users = new List<User>();
            }
        }

        private void LoadRooms()
        {
            if (File.Exists(RoomsFilePath))
            {
                var json = File.ReadAllText(RoomsFilePath);
                Rooms = JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
            }
            else
            {
                Rooms = new List<Room>();
            }
        }


        private void SaveUsers()
        {
            var json = JsonSerializer.Serialize(Users);
            File.WriteAllText(UsersFilePath, json);
        }

        private void SaveRooms()
        {
            var json = JsonSerializer.Serialize(Rooms);
            File.WriteAllText(RoomsFilePath, json);
        }

        private void Normal_Click(object sender, EventArgs e)
        {
            Form setNormalForm = new Form
            {
                Text = "Set Room to Normal",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            };
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            // Label for Room ID
            var lblRoomId = new Label
            {
                Text = "Room ID:",
                AutoSize = true
            };

            // TextBox for Room ID
            var txtRoomId = new TextBox
            {
                Width = 200
            };

            // Button to set to normal
            var btnSetNormal = new Button
            {
                Text = "Set to Normal",
                Dock = DockStyle.Bottom
            };

            // Button click event
            btnSetNormal.Click += (s, ev) =>
            {
                string roomId = txtRoomId.Text.Trim();
                var room = Rooms.FirstOrDefault(r => r.Id == roomId);

                if (room != null)
                {
                    room.State = RoomState.Normal;

                    // Change state of all rooms in the same building
                    foreach (var r in Rooms.Where(r => r.Building == room.Building))
                    {
                        r.State = RoomState.Normal;
                    }

                    string logMessage = $"Room {room.Id} in {room.Building} Building , Floor {room.Floor}, Room {room.RoomNumber} state changed to {room.State}";
                    LogAccessAttempt("System", room.Id, false, null, room, logMessage);
                    MessageBox.Show($"Room {room.Id} and all rooms in {room.Building} Building have been set to NORMAL mode.");
                }
                else
                {
                    MessageBox.Show("Room not found.");
                }

                setNormalForm.Close();
            };

            // Add controls to the panel
            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(txtRoomId);

            // Add panel and button to the form
            setNormalForm.Controls.Add(panel);
            setNormalForm.Controls.Add(btnSetNormal);

            setNormalForm.ShowDialog();
        }

        private void Emergency_Click(object sender, EventArgs e)
        {
            Form setEmergencyForm = new Form
            {
                Text = "Set Room to Emergency",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            // Create a panel to arrange controls vertically
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            // Label for Room ID
            var lblRoomId = new Label
            {
                Text = "Room ID:",
                AutoSize = true
            };

            // TextBox for Room ID
            var txtRoomId = new TextBox
            {
                Width = 200
            };

            // Button to set emergency state
            var btnSetEmergency = new Button
            {
                Text = "Set to Emergency",
                Dock = DockStyle.Bottom
            };

            // Button click event
            btnSetEmergency.Click += (s, ev) =>
            {
                string roomId = txtRoomId.Text.Trim();
                var room = Rooms.FirstOrDefault(r => r.Id == roomId);

                if (room != null)
                {
                    room.State = RoomState.Emergency;

                    // Change state of all rooms in the same building
                    foreach (var r in Rooms.Where(r => r.Building == room.Building))
                    {
                        r.State = RoomState.Emergency;
                    }

                    string logMessage = $"Room {room.Id} in {room.Building} Building, Floor {room.Floor}, Room {room.RoomNumber} state changed to {room.State}";
                    LogAccessAttempt("System", room.Id, false, null, room, logMessage);
                    MessageBox.Show($"Room {room.Id} and all rooms in {room.Building} Building have been set to EMERGENCY mode.");
                }
                else
                {
                    MessageBox.Show("Room not found.");
                }

                setEmergencyForm.Close();
            };

            // Add controls to the panel
            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(txtRoomId);

            // Add panel and button to the form
            setEmergencyForm.Controls.Add(panel);
            setEmergencyForm.Controls.Add(btnSetEmergency);

            setEmergencyForm.ShowDialog();
        }

        private void AddRoom_Click(object sender, EventArgs e)
        {
            // Create the Add Room form
            Form addRoomForm = new Form
            {
                Text = "Add Room",
                Size = new Size(300, 300)
            };

            // Labels and textboxes for Building, Floor, and Room Number
            var lblBuilding = new Label { Text = "Building", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtBuilding = new TextBox { Dock = DockStyle.Top };

            var lblRoomFloor = new Label { Text = "Room Floor", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtRoomFloor = new TextBox { Dock = DockStyle.Top };

            var lblRoomNumber = new Label { Text = "Room Number", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtRoomNumber = new TextBox { Dock = DockStyle.Top };

            // Label and dropdown for Room Type
            var lblRoomType = new Label { Text = "Room Type", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var cmbRoomType = new ComboBox
            {
                Dock = DockStyle.Top
            };

            // Populate ComboBox with room types
            cmbRoomType.Items.Add("Lecture Hall");
            cmbRoomType.Items.Add("Teaching Room");
            cmbRoomType.Items.Add("Secure Room");
            cmbRoomType.Items.Add("Meeting Room");
            cmbRoomType.SelectedIndex = 0; // Default to the first item

            // Save button
            var btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom };

            // Click event for the Save button
            btnSave.Click += (s, ev) =>
            {
                // Retrieve input values
                string building = txtBuilding.Text.Trim();
                string floor = txtRoomFloor.Text.Trim();
                string number = txtRoomNumber.Text.Trim();
                string roomType = cmbRoomType.SelectedItem.ToString();

                // Input validation
                if (string.IsNullOrEmpty(building) || string.IsNullOrEmpty(floor) || string.IsNullOrEmpty(number))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (!int.TryParse(floor, out _) || !int.TryParse(number, out _))
                {
                    MessageBox.Show("Room Floor and Room Number must be numeric.");
                    return;
                }

                // Generate Room ID
                string roomId = $"{building.Substring(0, 2).ToUpper()}{floor}{number}";

                // Automatically set RoomState to Normal
                RoomState state = RoomState.Normal;

                // Create a new Room object and add it to the collection
                var room = new Room(roomId, roomType, state, building, floor, number);
                Rooms.Add(room);

                // Save rooms to persist changes
                SaveRooms();

                MessageBox.Show($"Room {room.Id} added successfully.");
                addRoomForm.Close();
            };


            // Add controls to the form
            addRoomForm.Controls.AddRange(new Control[] { btnSave, txtRoomNumber, lblRoomNumber, txtRoomFloor, lblRoomFloor, txtBuilding, lblBuilding, cmbRoomType, lblRoomType });

            // Show the form
            addRoomForm.ShowDialog();
        }

        private void RemoveRoom_Click(object sender, EventArgs e)
        {
            // Create a new form for removing a room
            Form removeRoomForm = new Form
            {
                Text = "Remove Room",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            // Create a panel for organizing the layout
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            // Label for Room ID
            var lblRoomId = new Label
            {
                Text = "Room ID:",
                AutoSize = true
            };

            // TextBox for Room ID input
            var txtRoomId = new TextBox
            {
                Width = 200
            };

            // Button to remove the room
            var btnRemoveRoom = new Button
            {
                Text = "Remove Room",
                Dock = DockStyle.Bottom
            };

            // Button click event for removing the room
            btnRemoveRoom.Click += (s, ev) =>
            {
                string roomId = txtRoomId.Text.Trim();
                var room = Rooms.FirstOrDefault(r => r.Id == roomId);

                if (room != null)
                {
                    Rooms.Remove(room);
                    MessageBox.Show($"Room {room.Id} removed successfully.");
                }
                else
                {
                    MessageBox.Show("Room not found.");
                }

                removeRoomForm.Close();
            };

            // Add controls to the panel
            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(txtRoomId);

            // Add panel and button to the form
            removeRoomForm.Controls.Add(panel);
            removeRoomForm.Controls.Add(btnRemoveRoom);

            // Show the form as a dialog
            removeRoomForm.ShowDialog();
        }

        private void UpdateRoomSettings_Click(object sender, EventArgs e)
        {
            if (!Rooms.Any())
            {
                MessageBox.Show("No rooms available to edit.");
                return;
            }

            // Create a selection form to choose a room to edit
            Form selectRoomForm = new Form
            {
                Text = "Select Room to Update",
                Size = new Size(700, 300)
            };

            var dataGridView = new DataGridView
            {
                DataSource = Rooms.OrderBy(r => r.Id).ToList(),
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            var btnEdit = new Button { Text = "Edit Selected Room", Dock = DockStyle.Bottom };

            btnEdit.Click += (s, ev) =>
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a room to edit.");
                    return;
                }

                var selectedRow = dataGridView.SelectedRows[0];
                var selectedRoom = (Room)selectedRow.DataBoundItem;

                selectRoomForm.Close();
                OpenUpdateRoomForm(selectedRoom);
            };

            selectRoomForm.Controls.Add(dataGridView);
            selectRoomForm.Controls.Add(btnEdit);
            selectRoomForm.ShowDialog();
        }
        private void OpenUpdateRoomForm(Room room)
        {
            Form updateRoomForm = new Form
            {
                Text = $"Update Room - {room.Id}",
                Size = new Size(400, 300)
            };

            // Create a TableLayoutPanel for better alignment
            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                AutoSize = true,
                Padding = new Padding(10)
            };

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // For labels
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70)); // For input fields

            // Create controls for each editable property
            var lblRoomType = new Label { Text = "Room Type:", TextAlign = ContentAlignment.MiddleLeft };
            var cmbRoomType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList // Ensure it's a dropdown, not editable
            };
            cmbRoomType.Items.Add("Lecture Hall");
            cmbRoomType.Items.Add("Teaching Room");
            cmbRoomType.Items.Add("Secure Room");
            cmbRoomType.Items.Add("Meeting Room");
            cmbRoomType.SelectedItem = room.Type;

            var lblBuilding = new Label { Text = "Building:", TextAlign = ContentAlignment.MiddleLeft };
            var txtBuilding = new TextBox { Text = room.Building };

            var lblFloor = new Label { Text = "Floor:", TextAlign = ContentAlignment.MiddleLeft };
            var txtFloor = new TextBox { Text = room.Floor };

            var lblRoomNumber = new Label { Text = "Room Number:", TextAlign = ContentAlignment.MiddleLeft };
            var txtRoomNumber = new TextBox { Text = room.RoomNumber };

            var btnSave = new Button { Text = "Save Changes", Dock = DockStyle.Bottom };

            btnSave.Click += (s, ev) =>
            {
                // Update room properties with user input
                room.Type = cmbRoomType.SelectedItem.ToString();
                room.Building = txtBuilding.Text;
                room.Floor = txtFloor.Text;
                room.RoomNumber = txtRoomNumber.Text;

                MessageBox.Show($"Room {room.Id} updated successfully.");
                updateRoomForm.Close();
            };

            // Add controls to the table layout in pairs
            tableLayout.Controls.Add(lblRoomType, 0, 0);
            tableLayout.Controls.Add(cmbRoomType, 1, 0);
            tableLayout.Controls.Add(lblBuilding, 0, 1);
            tableLayout.Controls.Add(txtBuilding, 1, 1);
            tableLayout.Controls.Add(lblFloor, 0, 2);
            tableLayout.Controls.Add(txtFloor, 1, 2);
            tableLayout.Controls.Add(lblRoomNumber, 0, 3);
            tableLayout.Controls.Add(txtRoomNumber, 1, 3);

            // Add TableLayoutPanel and Save button to the form
            updateRoomForm.Controls.Add(tableLayout);
            updateRoomForm.Controls.Add(btnSave);

            updateRoomForm.ShowDialog();
        }

        private void ShowLogFiles_Click(object sender, EventArgs e)
        {
            // Display log files to the user
            //var logFiles = Directory.GetFiles(LogDirectory, "*.txt");
            //MessageBox.Show(string.Join(Environment.NewLine, logFiles));
            string logFile = Path.Combine(LogDirectory, $"room_access_log_{DateTime.Now:yyyy-MM-dd}.txt");

            if (!File.Exists(logFile))
            {
                MessageBox.Show("No logs found for today.");
                return;
            }

            string logContents = File.ReadAllText(logFile);

            Form logViewer = new Form
            {
                Text = "Log Viewer",
                Size = new Size(600, 400)
            };

            var textBox = new RichTextBox
            {
                Text = logContents,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };

            logViewer.Controls.Add(textBox);
            logViewer.Show();
        }

        private void CreateSwipeInput_Click(object sender, EventArgs e)
        {
            // Create a form for user input
            Form swipeInputForm = new Form
            {
                Text = "Create Swipe Input",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            // Label and TextBox for User ID
            var lblUserId = new Label
            {
                Text = "Enter User ID:",
                AutoSize = true
            };
            var txtUserId = new TextBox
            {
                Width = 200
            };

            // Label and TextBox for Room ID
            var lblRoomId = new Label
            {
                Text = "Enter Room ID:",
                AutoSize = true
            };
            var txtRoomId = new TextBox
            {
                Width = 200
            };

            // Button to submit swipe input
            var btnSubmit = new Button
            {
                Text = "Submit",
                Dock = DockStyle.Bottom
            };

            btnSubmit.Click += (buttonSender, eventArgs) =>
            {
                string inputUserId = txtUserId.Text.Trim();
                string inputRoomId = txtRoomId.Text.Trim();
                DateTime selectedSwipeTime = dateTimePicker1.Value; // Ensure this is set correctly

                var currentUser = Users.FirstOrDefault(u => u.UserId == inputUserId);
                var targetRoom = Rooms.FirstOrDefault(r => r.Id == inputRoomId);

                if (currentUser == null || targetRoom == null)
                {
                    LogAccessAttempt(inputUserId, inputRoomId, false, null, targetRoom, selectedSwipeTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    MessageBox.Show("Access Denied: User or Room not found.");
                    return;
                }

                bool canAccess = CanAccess(currentUser, targetRoom, selectedSwipeTime);
                LogAccessAttempt(currentUser.UserId, targetRoom.Id, canAccess, currentUser.Roles.ToString(), targetRoom, selectedSwipeTime.ToString("yyyy-MM-dd HH:mm:ss"));

                MessageBox.Show(canAccess ? "Access Granted" : "Access Denied");
                swipeInputForm.Close();
            };




            // Add controls to the panel
            panel.Controls.Add(lblUserId);
            panel.Controls.Add(txtUserId);
            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(txtRoomId);

            // Add panel and button to the form
            swipeInputForm.Controls.Add(panel);
            swipeInputForm.Controls.Add(btnSubmit);

            swipeInputForm.ShowDialog();
        }

        private bool CanAccess(User user, Room room, DateTime selectedDateTime)
        {
            var currentTime = selectedDateTime.TimeOfDay;

            // Emergency Mode
            if (room.State == RoomState.Emergency)
            {
                if (user.Roles == Role.EmergencyResponder || user.Roles == Role.Security)
                    return true;

                return false;
            }

            // Normal Mode
            if (user.Roles == Role.StaffMember)
            {
                return currentTime >= TimeSpan.Parse("05:30") && currentTime <= TimeSpan.Parse("23:59");
            }
            else if (user.Roles == Role.Student)
            {
                return currentTime >= TimeSpan.Parse("08:30") && currentTime <= TimeSpan.Parse("22:00")
                       && (room.Type == "Lecture Hall" || room.Type == "Teaching Room");
            }
            else if (user.Roles == Role.Visitor)
            {
                return currentTime >= TimeSpan.Parse("08:30") && currentTime <= TimeSpan.Parse("22:00")
                       && room.Type == "Lecture Hall";
            }
            else if (user.Roles == Role.ContractCleaner)
            {
                return (currentTime >= TimeSpan.Parse("05:30") && currentTime <= TimeSpan.Parse("10:30") ||
                        currentTime >= TimeSpan.Parse("17:30") && currentTime <= TimeSpan.Parse("22:30"))
                       && room.Type != "Secure Room";
            }
            else if (user.Roles == Role.Manager || user.Roles == Role.Security)
            {
                return true;
            }

            return false;
        }



        private void LogAccessAttempt(string userId, string roomId, bool accessGranted, string role, Room room, string selectedSwipeTime, string logMessage = null)
        {
            Directory.CreateDirectory(LogDirectory);
            string logFile = Path.Combine(LogDirectory, $"room_access_log_{DateTime.Now:yyyy-MM-dd}.txt");

            string roomState = room?.State != null ? room.State.ToString() : "Unknown";
            string userName = Users.FirstOrDefault(u => u.UserId == userId)?.Name ?? "Unknown"; // Get user name if available
            string logEntry;

            if (logMessage != null)
            {
                logEntry = $"{selectedSwipeTime}, {logMessage}";
            }
            else
            {
                logEntry = $"{selectedSwipeTime},{userId},{userName},{role},{roomId},{room?.Building ?? "N/A"},{room?.Floor ?? "N/A"},{room?.RoomNumber ?? "N/A"},{(accessGranted ? "Granted" : "Denied")},{roomState}";
            }

            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }



        private void AddUser_Click(object sender, EventArgs e)
        {
            Form addUserForm = new Form
            {
                Text = "Add User",
                Size = new Size(300, 300)
            };

            var lblUserId = new Label { Text = "User ID", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtUserId = new TextBox { Dock = DockStyle.Top };

            var lblName = new Label { Text = "Name", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtName = new TextBox { Dock = DockStyle.Top };

            var lblRole = new Label { Text = "Role", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            // Create the ComboBox for selecting a role
            var cmbRole = new ComboBox { Dock = DockStyle.Top };
            cmbRole.DataSource = Enum.GetValues(typeof(Role));  // Populate ComboBox with Role enum values


            var btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom };
            btnSave.Click += (s, ev) =>
            {
                if (Users.Any(u => u.UserId == txtUserId.Text))
                {
                    MessageBox.Show("User ID already exists.");
                }
                else
                {
                    Role selectedRole = (Role)cmbRole.SelectedItem;

                    var user = new User(txtUserId.Text, txtName.Text, selectedRole);
                    Users.Add(user);
                    SaveUsers();
                    MessageBox.Show($"User {user.Name} added.");
                }
                addUserForm.Close();
            };

            addUserForm.Controls.AddRange(new Control[] { btnSave, cmbRole, lblRole, txtName, lblName, txtUserId, lblUserId });
            addUserForm.ShowDialog();
        }

        private void RemoveUser_Click(object sender, EventArgs e)
        {
            Form removeUserForm = new Form
            {
                Text = "Remove User",
                Size = new Size(300, 200)
            };

            var lblUserId = new Label { Text = "User ID", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtUserId = new TextBox { Dock = DockStyle.Top };

            var btnRemove = new Button { Text = "Remove", Dock = DockStyle.Bottom };
            btnRemove.Click += (s, ev) =>
            {
                var user = Users.FirstOrDefault(u => u.UserId == txtUserId.Text);
                if (user != null)
                {
                    Users.Remove(user);
                    SaveUsers();
                    MessageBox.Show($"User {user.Name} removed.");
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                removeUserForm.Close();
            };

            removeUserForm.Controls.AddRange(new Control[] { btnRemove, txtUserId, lblUserId });
            removeUserForm.ShowDialog();
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            Form updateUserForm = new Form
            {
                Text = "Update User",
                Size = new Size(300, 300)
            };

            var lblUserId = new Label { Text = "User ID", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtUserId = new TextBox { Dock = DockStyle.Top };

            var lblName = new Label { Text = "New Name", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var txtName = new TextBox { Dock = DockStyle.Top };

            var lblRole = new Label { Text = "New Role", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleLeft };
            var cmbRole = new ComboBox { Dock = DockStyle.Top };
            cmbRole.DataSource = Enum.GetValues(typeof(Role));  // Populate ComboBox with Role enum values

            var btnUpdate = new Button { Text = "Update", Dock = DockStyle.Bottom };
            btnUpdate.Click += (s, ev) =>
            {
                var user = Users.FirstOrDefault(u => u.UserId == txtUserId.Text);
                if (user != null)
                {
                    user.Name = txtName.Text;
                    user.Roles = (Role)cmbRole.SelectedItem;
                    SaveUsers();
                    MessageBox.Show($"User {user.UserId} updated.");
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                updateUserForm.Close();
            };

            updateUserForm.Controls.AddRange(new Control[] { btnUpdate, cmbRole, lblRole, txtName, lblName, txtUserId, lblUserId });
            updateUserForm.ShowDialog();
        }

        private void ViewUsers_Click(object sender, EventArgs e)
        {
            var dataGridView = new DataGridView
            {
                DataSource = Users.OrderBy(u => u.Name).ToList(),
                Dock = DockStyle.Fill
            };

            Form usersForm = new Form
            {
                Text = "Users",
                Size = new Size(400, 300)
            };
            usersForm.Controls.Add(dataGridView);
            usersForm.Show();
        }

        private void ViewRooms_Click(object sender, EventArgs e)
        {
            var dataGridView = new DataGridView
            {
                DataSource = Rooms.OrderBy(r => r.Id).ToList(),
                Dock = DockStyle.Fill
            };

            Form roomsForm = new Form
            {
                Text = "Rooms",
                Size = new Size(700, 300)
            };
            roomsForm.Controls.Add(dataGridView);
            roomsForm.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected DateTime from the DateTimePicker
            DateTime selectedDateTime = dateTimePicker1.Value;

            // Display the selected date and time in a MessageBox or log it
            MessageBox.Show($"Selected Date and Time: {selectedDateTime}");

            // Now, you can use the selectedDateTime in your swipe card logic
            // For example, updating the swipe input logic based on the manually selected time:

            Form swipeInputForm = new Form
            {
                Text = "Create Swipe Input",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                AutoSize = true,
                WrapContents = false
            };

            // Label and TextBox for User ID
            var lblUserId = new Label
            {
                Text = "Enter User ID:",
                AutoSize = true
            };
            var txtUserId = new TextBox
            {
                Width = 200
            };

            // Label and TextBox for Room ID
            var lblRoomId = new Label
            {
                Text = "Enter Room ID:",
                AutoSize = true
            };
            var txtRoomId = new TextBox
            {
                Width = 200
            };

            // Button to submit swipe input
            var btnSubmit = new Button
            {
                Text = "Submit",
                Dock = DockStyle.Bottom
            };

            btnSubmit.Click += (s, ev) =>
            {
                string inputUserId = txtUserId.Text.Trim();
                string inputRoomId = txtRoomId.Text.Trim();
                DateTime selectedSwipeTime = dateTimePicker1.Value;

                var currentUser = Users.FirstOrDefault(u => u.UserId == inputUserId);
                var targetRoom = Rooms.FirstOrDefault(r => r.Id == inputRoomId);

                if (currentUser == null || targetRoom == null)
                {
                    LogAccessAttempt(inputUserId, inputRoomId, false, null, targetRoom, selectedSwipeTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    MessageBox.Show("Access Denied: User or Room not found.");
                    return;
                }

                bool canAccess = CanAccess(currentUser, targetRoom, selectedSwipeTime);
                LogAccessAttempt(currentUser.UserId, targetRoom.Id, canAccess, currentUser.Roles.ToString(), targetRoom, selectedSwipeTime.ToString("yyyy-MM-dd HH:mm:ss"));

                MessageBox.Show(canAccess ? "Access Granted" : "Access Denied");
                swipeInputForm.Close();
            };

            // Add controls to the panel
            panel.Controls.Add(lblUserId);
            panel.Controls.Add(txtUserId);
            panel.Controls.Add(lblRoomId);
            panel.Controls.Add(txtRoomId);

            // Add panel and button to the form
            swipeInputForm.Controls.Add(panel);
            swipeInputForm.Controls.Add(btnSubmit);

            swipeInputForm.ShowDialog();
        }
    }

    public enum Role
    {
        StaffMember,
        Student,
        Visitor,
        ContractCleaner,
        Manager,
        Security,
        EmergencyResponder
    }
    public class User
    {
        public string UserId { get; set; }  // Unique User ID (e.g., Swipe Card ID)
        public string Name { get; set; }
        public Role Roles { get; set; }  // List of roles assigned to the user

        // Constructor to initialize the user object
        public User(string userId, string name, Role roles)
        {
            UserId = userId;
            Name = name;
            Roles = roles;
        }
    }

    public class Room
    {
        public string Id { get; }
        public string Type { get; set; }
        public string Building { get; set; } // New property for Building
        public string Floor { get; set; } // New property for Floor
        public string RoomNumber { get; set; } // New property for Room Number
        public RoomState State { get; set; }

        public Room(string id, string type, RoomState state, string building = "", string floor = "", string roomNumber = "")
        {
            Id = id;
            Type = type;
            State = state;
            Building = building;
            Floor = floor;
            RoomNumber = roomNumber;
        }
    }


    public enum RoomState
    {
        Normal,
        Emergency
    }



}
