using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace bai1
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Appointment> appointments = new();
        private readonly BindingList<Appointment> filteredAppointments = new();
        private readonly BindingSource appointmentSource = new();
        private Appointment? selectedAppointment;

        private static readonly string[] AppointmentStatuses =
        {
            "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy"
        };

        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            doctorComboBox.Items.AddRange(new object[]
            {
                "BS. Nguyễn Văn An", "BS. Trần Thị Bình", "BS. Lê Minh Cường"
            });
            doctorComboBox.SelectedIndex = 0;
            statusComboBox.Items.AddRange(AppointmentStatuses);
            statusComboBox.SelectedIndex = 0;
            statusFilterComboBox.Items.AddRange(AppointmentStatuses);

            appointments.Add(new Appointment
            {
                AppointmentId = "LH001",
                PatientName = "Nguyễn Minh Anh",
                Phone = "0912345678",
                AppointmentDate = DateTime.Today.AddHours(9),
                Doctor = "BS. Nguyễn Văn An",
                Reason = "Tái khám định kỳ",
                Status = "Chờ khám"
            });
            appointments.Add(new Appointment
            {
                AppointmentId = "LH002",
                PatientName = "Trần Quốc Việt",
                Phone = "0987654321",
                AppointmentDate = DateTime.Today.AddDays(1).AddHours(14),
                Doctor = "BS. Trần Thị Bình",
                Reason = "Đau đầu",
                Status = "Chờ khám"
            });

            appointmentSource.DataSource = filteredAppointments;
            appointmentsGridView.DataSource = appointmentSource;
            appointmentDateTimePicker.Value = DateTime.Now.AddHours(1);
            dateFilterDateTimePicker.Value = DateTime.Today;
            RefreshFilteredAppointments();
            ClearInputs();
        }

        private void RefreshFilteredAppointments()
        {
            string search = searchTextBox.Text.Trim();
            bool filterByDate = dateFilterCheckBox.Checked;
            DateTime selectedDate = dateFilterDateTimePicker.Value.Date;
            string? selectedStatus = statusFilterComboBox.SelectedIndex > 0
                ? statusFilterComboBox.SelectedItem?.ToString()
                : null;

            filteredAppointments.RaiseListChangedEvents = false;
            filteredAppointments.Clear();
            foreach (Appointment appointment in appointments)
            {
                bool matchesSearch = search.Length == 0
                    || appointment.PatientName.Contains(search, StringComparison.CurrentCultureIgnoreCase)
                    || appointment.Phone.Contains(search, StringComparison.OrdinalIgnoreCase);
                bool matchesDate = !filterByDate || appointment.AppointmentDate.Date == selectedDate;
                bool matchesStatus = selectedStatus is null || appointment.Status == selectedStatus;
                if (matchesSearch && matchesDate && matchesStatus)
                {
                    filteredAppointments.Add(appointment);
                }
            }
            filteredAppointments.RaiseListChangedEvents = true;
            filteredAppointments.ResetBindings();
            countStatusLabel.Text = $"Số lịch hẹn sau khi lọc: {filteredAppointments.Count}";
        }

        private void actionButton_Click(object? sender, EventArgs e)
        {
            if (sender == addButton)
            {
                AddAppointment();
            }
            else if (sender == updateButton)
            {
                UpdateAppointment();
            }
            else if (sender == deleteButton)
            {
                DeleteAppointment();
            }
            else if (sender == clearButton)
            {
                ClearInputs();
            }
        }

        private void AddAppointment()
        {
            if (!TryReadAppointment(out Appointment? appointment))
            {
                return;
            }

            if (appointments.Any(item => item.AppointmentId.Equals(appointment.AppointmentId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(appointmentIdTextBox, "Mã lịch hẹn phải là duy nhất.");
                appointmentIdTextBox.Focus();
                return;
            }

            appointments.Add(appointment);
            RefreshFilteredAppointments();
            SelectAppointment(appointment);
            MessageBox.Show("Đã thêm lịch hẹn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateAppointment()
        {
            if (selectedAppointment is null)
            {
                MessageBox.Show("Hãy chọn một lịch hẹn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryReadAppointment(out Appointment? updated))
            {
                return;
            }

            if (appointments.Any(item => item != selectedAppointment
                && item.AppointmentId.Equals(updated.AppointmentId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(appointmentIdTextBox, "Mã lịch hẹn phải là duy nhất.");
                appointmentIdTextBox.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn cập nhật lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            selectedAppointment.CopyFrom(updated);
            appointments.ResetItem(appointments.IndexOf(selectedAppointment));
            RefreshFilteredAppointments();
            SelectAppointment(selectedAppointment);
        }

        private void DeleteAppointment()
        {
            if (selectedAppointment is null)
            {
                MessageBox.Show("Hãy chọn một lịch hẹn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lịch hẹn đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            appointments.Remove(selectedAppointment);
            ClearInputs();
            RefreshFilteredAppointments();
        }

        private bool TryReadAppointment(out Appointment appointment)
        {
            ClearErrors();
            appointment = new Appointment
            {
                AppointmentId = appointmentIdTextBox.Text.Trim(),
                PatientName = patientNameTextBox.Text.Trim(),
                Phone = phoneTextBox.Text.Trim(),
                AppointmentDate = appointmentDateTimePicker.Value,
                Doctor = doctorComboBox.SelectedItem?.ToString() ?? string.Empty,
                Reason = reasonTextBox.Text.Trim(),
                Status = statusComboBox.SelectedItem?.ToString() ?? AppointmentStatuses[0]
            };

            bool valid = true;
            if (string.IsNullOrWhiteSpace(appointment.AppointmentId))
            {
                errorProvider.SetError(appointmentIdTextBox, "Vui lòng nhập mã lịch hẹn.");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(appointment.PatientName))
            {
                errorProvider.SetError(patientNameTextBox, "Vui lòng nhập họ tên bệnh nhân.");
                valid = false;
            }
            if (!Regex.IsMatch(appointment.Phone, @"^(\+84|0)\d{9,10}$"))
            {
                errorProvider.SetError(phoneTextBox, "Số điện thoại không hợp lệ.");
                valid = false;
            }
            if (appointment.AppointmentDate < DateTime.Now)
            {
                errorProvider.SetError(appointmentDateTimePicker, "Ngày giờ hẹn không được nằm trong quá khứ.");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(appointment.Reason))
            {
                errorProvider.SetError(reasonTextBox, "Vui lòng nhập lý do khám.");
                valid = false;
            }

            if (!valid)
            {
                MessageBox.Show("Vui lòng kiểm tra các trường bị đánh dấu.", "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return valid;
        }

        private void appointmentsGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (appointmentsGridView.CurrentRow?.DataBoundItem is Appointment appointment)
            {
                SelectAppointment(appointment);
            }
        }

        private void SelectAppointment(Appointment appointment)
        {
            selectedAppointment = appointment;
            appointmentIdTextBox.Text = appointment.AppointmentId;
            patientNameTextBox.Text = appointment.PatientName;
            phoneTextBox.Text = appointment.Phone;
            appointmentDateTimePicker.Value = appointment.AppointmentDate < DateTimePicker.MinimumDateTime
                ? DateTimePicker.MinimumDateTime
                : appointment.AppointmentDate;
            doctorComboBox.SelectedItem = appointment.Doctor;
            reasonTextBox.Text = appointment.Reason;
            statusComboBox.SelectedItem = appointment.Status;
            ClearErrors();
        }

        private void ClearInputs()
        {
            selectedAppointment = null;
            appointmentIdTextBox.Clear();
            patientNameTextBox.Clear();
            phoneTextBox.Clear();
            appointmentDateTimePicker.Value = DateTime.Now.AddHours(1);
            doctorComboBox.SelectedIndex = doctorComboBox.Items.Count > 0 ? 0 : -1;
            reasonTextBox.Clear();
            statusComboBox.SelectedIndex = 0;
            appointmentsGridView.ClearSelection();
            ClearErrors();
        }

        private void ClearErrors()
        {
            errorProvider.Clear();
        }

        private void filterChanged(object? sender, EventArgs e)
        {
            RefreshFilteredAppointments();
        }

        private void exportCsvMenuItem_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = "lich-hen.csv",
                Title = "Xuất danh sách lịch hẹn"
            };
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            StringBuilder csv = new();
            csv.AppendLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");
            foreach (Appointment appointment in filteredAppointments)
            {
                csv.AppendLine(string.Join(",", new[]
                {
                    CsvValue(appointment.AppointmentId),
                    CsvValue(appointment.PatientName),
                    CsvValue(appointment.Phone),
                    CsvValue(appointment.AppointmentDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)),
                    CsvValue(appointment.Doctor),
                    CsvValue(appointment.Reason),
                    CsvValue(appointment.Status)
                }));
            }
            File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Đã xuất danh sách đang hiển thị ra tệp CSV.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string CsvValue(string value)
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
    }

    public sealed class Appointment
    {
        public string AppointmentId { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public void CopyFrom(Appointment source)
        {
            AppointmentId = source.AppointmentId;
            PatientName = source.PatientName;
            Phone = source.Phone;
            AppointmentDate = source.AppointmentDate;
            Doctor = source.Doctor;
            Reason = source.Reason;
            Status = source.Status;
        }
    }
}