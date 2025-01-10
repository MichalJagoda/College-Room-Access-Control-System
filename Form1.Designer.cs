namespace College_Room_Access_Control_System
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Normal = new System.Windows.Forms.Button();
            this.Emergency = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ShowLogFiles = new System.Windows.Forms.Button();
            this.AddRoom = new System.Windows.Forms.Button();
            this.RemoveRoom = new System.Windows.Forms.Button();
            this.UpdateRoomSettings = new System.Windows.Forms.Button();
            this.CreateSwipeInput = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.RemoveUser = new System.Windows.Forms.Button();
            this.UpdateUser = new System.Windows.Forms.Button();
            this.ViewUsers = new System.Windows.Forms.Button();
            this.ViewRooms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Normal
            // 
            this.Normal.Location = new System.Drawing.Point(100, 112);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(174, 71);
            this.Normal.TabIndex = 0;
            this.Normal.Text = "Normal";
            this.Normal.UseVisualStyleBackColor = true;
            this.Normal.Click += new System.EventHandler(this.Normal_Click);
            // 
            // Emergency
            // 
            this.Emergency.Location = new System.Drawing.Point(100, 177);
            this.Emergency.Name = "Emergency";
            this.Emergency.Size = new System.Drawing.Size(174, 71);
            this.Emergency.TabIndex = 1;
            this.Emergency.Text = "Emergency";
            this.Emergency.UseVisualStyleBackColor = true;
            this.Emergency.Click += new System.EventHandler(this.Emergency_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(700, 112);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // ShowLogFiles
            // 
            this.ShowLogFiles.Location = new System.Drawing.Point(700, 378);
            this.ShowLogFiles.Name = "ShowLogFiles";
            this.ShowLogFiles.Size = new System.Drawing.Size(174, 71);
            this.ShowLogFiles.TabIndex = 10;
            this.ShowLogFiles.Text = "Show Log Files";
            this.ShowLogFiles.UseVisualStyleBackColor = true;
            this.ShowLogFiles.Click += new System.EventHandler(this.ShowLogFiles_Click);
            // 
            // AddRoom
            // 
            this.AddRoom.Location = new System.Drawing.Point(100, 311);
            this.AddRoom.Name = "AddRoom";
            this.AddRoom.Size = new System.Drawing.Size(174, 71);
            this.AddRoom.TabIndex = 11;
            this.AddRoom.Text = "Add Room";
            this.AddRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddRoom.UseVisualStyleBackColor = true;
            this.AddRoom.Click += new System.EventHandler(this.AddRoom_Click);
            // 
            // RemoveRoom
            // 
            this.RemoveRoom.Location = new System.Drawing.Point(100, 378);
            this.RemoveRoom.Name = "RemoveRoom";
            this.RemoveRoom.Size = new System.Drawing.Size(174, 71);
            this.RemoveRoom.TabIndex = 12;
            this.RemoveRoom.Text = "Remove Room";
            this.RemoveRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.RemoveRoom.UseVisualStyleBackColor = true;
            this.RemoveRoom.Click += new System.EventHandler(this.RemoveRoom_Click);
            // 
            // UpdateRoomSettings
            // 
            this.UpdateRoomSettings.Location = new System.Drawing.Point(100, 443);
            this.UpdateRoomSettings.Name = "UpdateRoomSettings";
            this.UpdateRoomSettings.Size = new System.Drawing.Size(174, 71);
            this.UpdateRoomSettings.TabIndex = 13;
            this.UpdateRoomSettings.Text = "Update Room Settings";
            this.UpdateRoomSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UpdateRoomSettings.UseVisualStyleBackColor = true;
            this.UpdateRoomSettings.Click += new System.EventHandler(this.UpdateRoomSettings_Click);
            // 
            // CreateSwipeInput
            // 
            this.CreateSwipeInput.Location = new System.Drawing.Point(700, 311);
            this.CreateSwipeInput.Name = "CreateSwipeInput";
            this.CreateSwipeInput.Size = new System.Drawing.Size(174, 71);
            this.CreateSwipeInput.TabIndex = 14;
            this.CreateSwipeInput.Text = "Create Swipe Input";
            this.CreateSwipeInput.UseVisualStyleBackColor = true;
            this.CreateSwipeInput.Click += new System.EventHandler(this.CreateSwipeInput_Click);
            // 
            // AddUser
            // 
            this.AddUser.Location = new System.Drawing.Point(100, 595);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(174, 71);
            this.AddUser.TabIndex = 15;
            this.AddUser.Text = "Add User";
            this.AddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // RemoveUser
            // 
            this.RemoveUser.Location = new System.Drawing.Point(100, 661);
            this.RemoveUser.Name = "RemoveUser";
            this.RemoveUser.Size = new System.Drawing.Size(174, 71);
            this.RemoveUser.TabIndex = 16;
            this.RemoveUser.Text = "Remove User";
            this.RemoveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.RemoveUser.UseVisualStyleBackColor = true;
            this.RemoveUser.Click += new System.EventHandler(this.RemoveUser_Click);
            // 
            // UpdateUser
            // 
            this.UpdateUser.Location = new System.Drawing.Point(100, 728);
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.Size = new System.Drawing.Size(174, 71);
            this.UpdateUser.TabIndex = 17;
            this.UpdateUser.Text = "Update User";
            this.UpdateUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UpdateUser.UseVisualStyleBackColor = true;
            this.UpdateUser.Click += new System.EventHandler(this.UpdateUser_Click);
            // 
            // ViewUsers
            // 
            this.ViewUsers.Location = new System.Drawing.Point(100, 796);
            this.ViewUsers.Name = "ViewUsers";
            this.ViewUsers.Size = new System.Drawing.Size(174, 71);
            this.ViewUsers.TabIndex = 19;
            this.ViewUsers.Text = "View Users";
            this.ViewUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ViewUsers.UseVisualStyleBackColor = true;
            this.ViewUsers.Click += new System.EventHandler(this.ViewUsers_Click);
            // 
            // ViewRooms
            // 
            this.ViewRooms.Location = new System.Drawing.Point(100, 509);
            this.ViewRooms.Name = "ViewRooms";
            this.ViewRooms.Size = new System.Drawing.Size(174, 71);
            this.ViewRooms.TabIndex = 20;
            this.ViewRooms.Text = "View Rooms";
            this.ViewRooms.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ViewRooms.UseVisualStyleBackColor = true;
            this.ViewRooms.Click += new System.EventHandler(this.ViewRooms_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2201, 1257);
            this.Controls.Add(this.ViewRooms);
            this.Controls.Add(this.ViewUsers);
            this.Controls.Add(this.UpdateUser);
            this.Controls.Add(this.RemoveUser);
            this.Controls.Add(this.AddUser);
            this.Controls.Add(this.CreateSwipeInput);
            this.Controls.Add(this.UpdateRoomSettings);
            this.Controls.Add(this.RemoveRoom);
            this.Controls.Add(this.AddRoom);
            this.Controls.Add(this.ShowLogFiles);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Emergency);
            this.Controls.Add(this.Normal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Normal;
        private System.Windows.Forms.Button Emergency;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ShowLogFiles;
        private System.Windows.Forms.Button AddRoom;
        private System.Windows.Forms.Button RemoveRoom;
        private System.Windows.Forms.Button UpdateRoomSettings;
        private System.Windows.Forms.Button CreateSwipeInput;
        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Button RemoveUser;
        private System.Windows.Forms.Button UpdateUser;
        private System.Windows.Forms.Button ViewUsers;
        private System.Windows.Forms.Button ViewRooms;
    }
}

