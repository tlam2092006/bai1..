namespace bai1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem exportCsvMenuItem;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel inputLayout;
        private TableLayoutPanel filterLayout;
        private Label appointmentIdLabel;
        private Label patientNameLabel;
        private Label phoneLabel;
        private Label appointmentDateLabel;
        private Label doctorLabel;
        private Label reasonLabel;
        private Label statusLabel;
        private TextBox appointmentIdTextBox;
        private TextBox patientNameTextBox;
        private TextBox phoneTextBox;
        private DateTimePicker appointmentDateTimePicker;
        private ComboBox doctorComboBox;
        private TextBox reasonTextBox;
        private ComboBox statusComboBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button clearButton;
        private Label searchLabel;
        private TextBox searchTextBox;
        private Label dateFilterLabel;
        private DateTimePicker dateFilterDateTimePicker;
        private CheckBox dateFilterCheckBox;
        private Label statusFilterLabel;
        private ComboBox statusFilterComboBox;
        private DataGridView appointmentsGridView;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel countStatusLabel;
        private ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            exportCsvMenuItem = new ToolStripMenuItem();
            mainLayout = new TableLayoutPanel();
            inputLayout = new TableLayoutPanel();
            filterLayout = new TableLayoutPanel();
            appointmentIdLabel = new Label();
            patientNameLabel = new Label();
            phoneLabel = new Label();
            appointmentDateLabel = new Label();
            doctorLabel = new Label();
            reasonLabel = new Label();
            statusLabel = new Label();
            appointmentIdTextBox = new TextBox();
            patientNameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            appointmentDateTimePicker = new DateTimePicker();
            doctorComboBox = new ComboBox();
            reasonTextBox = new TextBox();
            statusComboBox = new ComboBox();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            searchLabel = new Label();
            searchTextBox = new TextBox();
            dateFilterLabel = new Label();
            dateFilterDateTimePicker = new DateTimePicker();
            dateFilterCheckBox = new CheckBox();
            statusFilterLabel = new Label();
            statusFilterComboBox = new ComboBox();
            appointmentsGridView = new DataGridView();
            statusStrip = new StatusStrip();
            countStatusLabel = new ToolStripStatusLabel();
            errorProvider = new ErrorProvider(components);
            menuStrip.SuspendLayout();
            mainLayout.SuspendLayout();
            inputLayout.SuspendLayout();
            filterLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentsGridView).BeginInit();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();

            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1100, 24);
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCsvMenuItem });
            fileMenuItem.Text = "Tệp";
            exportCsvMenuItem.Text = "Xuất danh sách đang hiển thị ra CSV...";
            exportCsvMenuItem.Click += exportCsvMenuItem_Click;

            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 24);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(8);
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(inputLayout, 0, 0);
            mainLayout.Controls.Add(appointmentsGridView, 0, 1);

            inputLayout.ColumnCount = 8;
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            inputLayout.Dock = DockStyle.Fill;
            inputLayout.Padding = new Padding(0, 0, 0, 6);
            inputLayout.RowCount = 4;
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            ConfigureLabel(appointmentIdLabel, "Mã lịch hẹn:");
            ConfigureLabel(patientNameLabel, "Họ tên bệnh nhân:");
            ConfigureLabel(phoneLabel, "Số điện thoại:");
            ConfigureLabel(appointmentDateLabel, "Ngày giờ hẹn:");
            ConfigureLabel(doctorLabel, "Bác sĩ:");
            ConfigureLabel(reasonLabel, "Lý do khám:");
            ConfigureLabel(statusLabel, "Trạng thái:");
            appointmentIdTextBox.Dock = DockStyle.Fill;
            patientNameTextBox.Dock = DockStyle.Fill;
            phoneTextBox.Dock = DockStyle.Fill;
            appointmentDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            appointmentDateTimePicker.Dock = DockStyle.Fill;
            appointmentDateTimePicker.Format = DateTimePickerFormat.Custom;
            doctorComboBox.Dock = DockStyle.Fill;
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            reasonTextBox.Dock = DockStyle.Fill;
            reasonTextBox.Multiline = true;
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            statusComboBox.Dock = DockStyle.Fill;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            inputLayout.Controls.Add(appointmentIdLabel, 0, 0);
            inputLayout.Controls.Add(appointmentIdTextBox, 1, 0);
            inputLayout.Controls.Add(patientNameLabel, 2, 0);
            inputLayout.Controls.Add(patientNameTextBox, 3, 0);
            inputLayout.Controls.Add(phoneLabel, 4, 0);
            inputLayout.Controls.Add(phoneTextBox, 5, 0);
            inputLayout.Controls.Add(appointmentDateLabel, 6, 0);
            inputLayout.Controls.Add(appointmentDateTimePicker, 7, 0);
            inputLayout.Controls.Add(doctorLabel, 0, 1);
            inputLayout.Controls.Add(doctorComboBox, 1, 1);
            inputLayout.Controls.Add(statusLabel, 2, 1);
            inputLayout.Controls.Add(statusComboBox, 3, 1);
            inputLayout.Controls.Add(reasonLabel, 4, 1);
            inputLayout.SetRowSpan(reasonLabel, 2);
            inputLayout.Controls.Add(reasonTextBox, 5, 1);
            inputLayout.SetColumnSpan(reasonTextBox, 3);
            inputLayout.SetRowSpan(reasonTextBox, 2);

            addButton.Text = "Thêm";
            updateButton.Text = "Cập nhật";
            deleteButton.Text = "Xóa";
            clearButton.Text = "Làm mới";
            foreach (Button button in new[] { addButton, updateButton, deleteButton, clearButton })
            {
                button.AutoSize = true;
                button.Anchor = AnchorStyles.Left;
                button.Click += actionButton_Click;
            }
            inputLayout.Controls.Add(addButton, 0, 3);
            inputLayout.Controls.Add(updateButton, 1, 3);
            inputLayout.Controls.Add(deleteButton, 2, 3);
            inputLayout.Controls.Add(clearButton, 3, 3);

            filterLayout.ColumnCount = 6;
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            filterLayout.Dock = DockStyle.Fill;
            filterLayout.RowCount = 1;
            filterLayout.Controls.Add(searchLabel, 0, 0);
            filterLayout.Controls.Add(searchTextBox, 1, 0);
            filterLayout.Controls.Add(dateFilterLabel, 2, 0);
            filterLayout.Controls.Add(dateFilterDateTimePicker, 3, 0);
            filterLayout.Controls.Add(dateFilterCheckBox, 4, 0);
            filterLayout.Controls.Add(statusFilterComboBox, 5, 0);
            ConfigureLabel(searchLabel, "Tìm kiếm:");
            ConfigureLabel(dateFilterLabel, "Ngày:");
            searchTextBox.Dock = DockStyle.Fill;
            dateFilterDateTimePicker.CustomFormat = "dd/MM/yyyy";
            dateFilterDateTimePicker.Dock = DockStyle.Fill;
            dateFilterDateTimePicker.Format = DateTimePickerFormat.Custom;
            dateFilterCheckBox.Text = "Lọc ngày";
            dateFilterCheckBox.AutoSize = true;
            dateFilterCheckBox.CheckedChanged += filterChanged;
            statusFilterComboBox.Dock = DockStyle.Fill;
            statusFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusFilterComboBox.Items.Add("Tất cả trạng thái");
            statusFilterComboBox.SelectedIndex = 0;
            statusFilterComboBox.SelectedIndexChanged += filterChanged;
            searchTextBox.TextChanged += filterChanged;
            dateFilterDateTimePicker.ValueChanged += filterChanged;
            inputLayout.Controls.Add(filterLayout, 4, 3);
            inputLayout.SetColumnSpan(filterLayout, 4);

            appointmentsGridView.AllowUserToAddRows = false;
            appointmentsGridView.AllowUserToDeleteRows = false;
            appointmentsGridView.AutoGenerateColumns = false;
            appointmentsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appointmentsGridView.BackgroundColor = SystemColors.Window;
            appointmentsGridView.Dock = DockStyle.Fill;
            appointmentsGridView.ReadOnly = true;
            appointmentsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsGridView.MultiSelect = false;
            appointmentsGridView.RowHeadersVisible = false;
            appointmentsGridView.SelectionChanged += appointmentsGridView_SelectionChanged;
            AddGridColumn("AppointmentId", "Mã lịch", 90);
            AddGridColumn("PatientName", "Bệnh nhân", 150);
            AddGridColumn("Phone", "Số điện thoại", 110);
            AddGridColumn("AppointmentDate", "Ngày giờ hẹn", 130);
            AddGridColumn("Doctor", "Bác sĩ", 120);
            AddGridColumn("Reason", "Lý do khám", 180);
            AddGridColumn("Status", "Trạng thái", 100);

            statusStrip.Items.Add(countStatusLabel);
            statusStrip.Location = new Point(0, 424);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1100, 26);
            countStatusLabel.Text = "Số lịch hẹn: 0";

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(mainLayout);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(900, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lịch hẹn phòng khám";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            mainLayout.ResumeLayout(false);
            inputLayout.ResumeLayout(false);
            inputLayout.PerformLayout();
            filterLayout.ResumeLayout(false);
            filterLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentsGridView).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private static void ConfigureLabel(Label label, string text)
        {
            label.AutoSize = true;
            label.Anchor = AnchorStyles.Left;
            label.Text = text;
        }

        private void AddGridColumn(string propertyName, string headerText, int width)
        {
            appointmentsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Name = propertyName + "Column",
                MinimumWidth = width
            });
        }
    }
}