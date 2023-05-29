using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelMgt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Font = new Font("Georgia", 10);
            
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.Font = new Font("Georgia", 10);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.Font = new Font("Georgia", 10);
        }
        public static string RoomNo;
       
        public static string RoomType;
        public static string RoomCharge;
        public static string Names;
        public static string Roles;
        public static string Status;

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms rm = new Rooms();
            rm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Admin adb = new Admin();
            adb.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bindApp();
        }

        private void ok(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                RoomNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                RoomType = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                RoomCharge = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                CheckIn cn = new CheckIn();
                cn.Show();
            }
            else
            {
                RoomNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                RoomType = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                RoomCharge = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Reservation re = new Reservation();
                re.Show();
            }
        }
        public void bindApp()
        {
            DataTable dt = getDetails();
            dataGridView1.DataSource = dt;
        }
        public DataTable getDetails()
        {

            string app = "SELECT [RoomNo] as RmNo,[RoomType] AS RmType,[RoomCharges] AS RmCharges FROM Rooms WHERE RoomStatus = 'Vacant'";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void guestOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuestOrder goda = new GuestOrder();
            goda.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddToWareHouse awh = new AddToWareHouse();
            awh.Show();
        }

        private void resevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resvtn rs = new Resvtn();
            rs.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuestEntry ge = new GuestEntry();
            ge.Show();
        }
        public void bindCheckIn()
        {
            DataTable dt = getCheckIn();
            dataGridView2.DataSource = dt;
        }
        public DataTable getCheckIn()
        {

            string app = "SELECT [GuestName],[RoomNo] AS RmNo,[DateIn],[DateOut] FROM CheckIn WHERE CheckIn = '1'";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }
        public void bindRes()
        {
            DataTable dt = getRes();
            dataGridView3.DataSource = dt;
        }
        public DataTable getRes()
        {

            string app = "SELECT [ReservationNo]  AS RNo,[GuestName],[RoomHallNo] AS RmOrHall,[DateIn],[DateOut] FROM Res WHERE Status = '1' AND DATEDIFF(Day, DateOut, GETDATE()) <= 7";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindCheckIn();
            bindApp();
            bindRes();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView2.Columns[0].Width = 160;
            dataGridView3.Columns[0].Width = 50;
            //dataGridView3.Columns[2].Width = 50;
            dataGridView2.Columns[3].Width = 50;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].Width = 90;

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           BackUp ss = new BackUp();
            ss.Show();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction sp = new Transaction();
            sp.Show();
        }

        private void accountSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToWareHouse asm = new AddToWareHouse();
            asm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUsers css = new CreateUsers();
            css.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            GuestList gs = new GuestList();
            gs.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            CheckOut ckt = new CheckOut();
            ckt.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CheckInList ck = new CheckInList();
            ck.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindCheckinByDate();
            bindResByDate();
        }
        public void bindCheckinByDate()
        {
            DataTable dt = getCheckInByDate(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
            dataGridView2.DataSource = dt;
        }
        public void bindResByDate()
        {
            DataTable dt = getResByDate(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
            dataGridView3.DataSource = dt;
        }
        public DataTable getCheckInByDate(DateTime from, DateTime To)
        {

            string app = "SELECT [GuestName],[RoomNo] AS RmNo,[DateIn],[DateOut] FROM CheckIn WHERE DateIn Between @from AND @to";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", To);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }
        public DataTable getResByDate(DateTime from, DateTime To)
        {

            string app = "SELECT [ReservationNo] AS RNo,[GuestName],[RoomHallNo] AS Room_Or_Hall,[DateIn],[DateOut] FROM Res WHERE DateIn Between @from AND @to";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", To);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bindCheckIn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindCheckOut();
        }
        public void bindCheckOut()
        {
            DataTable dt = getCheckOut();
            dataGridView2.DataSource = dt;
        }
        public DataTable getCheckOut()
        {

            string app = "SELECT [GuestName],[RoomNo] AS RmNo,[DateIn],[DateOut] FROM CheckIn WHERE CheckIn = '0' AND DATEDIFF(Day, FinalDateOut, GETDATE()) <= 7";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AccountSummary asc = new AccountSummary();
            asc.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Home frm = new Home();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                Names = frm.adama;
                Roles = frm.roles;
                Status = frm.status;
                if (Status == "Admin" && Roles == "Manager")
                {
                    toolStripButton3.Enabled = true;
                    dataGridView1.Enabled = true;
                    roomsToolStripMenuItem.Enabled = true;
                    guestToolStripMenuItem.Enabled = true;
                    guestOrderToolStripMenuItem.Enabled = true;
                    resevationsToolStripMenuItem.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton8.Enabled = true;
                    toolStripButton2.Enabled = true;
                    toolStripButton4.Enabled = true;
                    toolStripButton3.Enabled = true;
                    toolStripButton5.Enabled = true;
                    expensesToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                    hotelInternalExpensesToolStripMenuItem.Enabled = true;
                }
                else if (Status == "Staff" && Roles == "Receptionist")
                {
                    dataGridView1.Enabled = true;
                    roomsToolStripMenuItem.Enabled = true;
                    guestToolStripMenuItem.Enabled = true;
                    guestOrderToolStripMenuItem.Enabled = true;
                    resevationsToolStripMenuItem.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton8.Enabled = true;
                    expensesToolStripMenuItem.Enabled = true;
                    hotelInternalExpensesToolStripMenuItem.Enabled = true;

                }
                else if (Status == "Staff" && Roles == "Accountant")
                {
                    toolStripButton4.Enabled = true;
                    dataGridView1.Enabled = true;
                    roomsToolStripMenuItem.Enabled = true;
                    guestToolStripMenuItem.Enabled = true;
                    guestOrderToolStripMenuItem.Enabled = true;
                    resevationsToolStripMenuItem.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton8.Enabled = true;
                    toolStripButton2.Enabled = true;
                     toolStripButton3.Enabled = true;
                    toolStripButton5.Enabled = true;
                    expensesToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                    hotelInternalExpensesToolStripMenuItem.Enabled = true;
                }
                else if (Status == "Staff" && Roles == "Supervisor")
                {
                    toolStripButton4.Enabled = true;
                    dataGridView1.Enabled = true;
                    roomsToolStripMenuItem.Enabled = true;
                    guestToolStripMenuItem.Enabled = true;
                    guestOrderToolStripMenuItem.Enabled = true;
                    resevationsToolStripMenuItem.Enabled = true;
                    toolStripButton7.Enabled = true;
                    toolStripButton8.Enabled = true;
                    toolStripButton2.Enabled = true;
                    toolStripButton5.Enabled = true;
                    expensesToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                    hotelInternalExpensesToolStripMenuItem.Enabled = true;
                }
                else if (Status == "Staff" && Roles != "Receptionist" && Roles != "Manager" && Roles != "Accountant" && Roles != "Supervisor")
                {
                    expensesToolStripMenuItem.Enabled = true;
                    guestOrderToolStripMenuItem.Enabled = true;
                    hotelInternalExpensesToolStripMenuItem.Enabled = true;
                }
               
                else
                {
                    MessageBox.Show("Failed login");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bindCheckIn();
            bindApp();
            bindRes();
            dataGridView1.Columns[0].Width = 68;
            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].Width = 90;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindResCurrent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindCheckOutToday();
        }
        public void bindCheckOutToday()
        {
            DataTable dt = getCheckOutToday();
            dataGridView2.DataSource = dt;
        }
        public DataTable getCheckOutToday()
        {

            string app = "SELECT [GuestName],[RoomNo] AS RmNo,[DateIn],[DateOut] FROM CheckIn WHERE CheckIn = '1' AND DATEDIFF(Day, GETDATE(), DateOut) BETWEEN 0 AND 1";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            bindCheckInOverstay();
        }
        public DataTable getCheckInOverstay()
        {

            string app = "SELECT [GuestName],[RoomNo] AS RmNo,[DateIn],[DateOut] FROM CheckIn WHERE CheckIn = '1' AND DATEDIFF(Day, DateOut, GETDATE()) > 1";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }
        public void bindCheckInOverstay()
        {
            DataTable dt = getCheckInOverstay();
            dataGridView2.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bindEndedRes();
        }
        public void bindEndedRes()
        {
            DataTable dt = getResEnded();
            dataGridView3.DataSource = dt;
        }
        public DataTable getResEnded()
        {

            string app = "SELECT [ReservationNo] AS RNo,[GuestName],[RoomHallNo] AS Room_Or_Hall,[DateIn],[DateOut] FROM Res WHERE [Status] ='1' AND DATEDIFF(Day, DateOut, GETDATE()) >= 1";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bindResRecent();
        }
        public void bindResRecent()
        {
            DataTable dt = getResRecent();
            dataGridView3.DataSource = dt;
        }
        public DataTable getResRecent()
        {

            string app = "SELECT [ReservationNo]  AS RNo,[GuestName],[RoomHallNo] AS Room_Or_Hall,[DateIn],[DateOut] FROM Res WHERE Status = '0' AND DATEDIFF(Day, DateOut, GETDATE()) <= 7";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bindResCurrent();
        }
        public void bindResCurrent()
        {
            DataTable dt = getResCurrent();
            dataGridView3.DataSource = dt;
        }
        public DataTable getResCurrent()
        {

            string app = "SELECT [ReservationNo]  AS RNo,[GuestName],[RoomHallNo] AS Room_Or_Hall,[DateIn],[DateOut] FROM Res WHERE Status = '1'";
            var con = new SqlConnection(conState.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = app;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            cmd.Dispose();
            return dt;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void guestOrderReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateRep rs = new GenerateRep();
            rs.Show();
        }

        private void checkInReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckInReport rs = new CheckInReport();
            rs.Show();
        }

        private void expensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenResReport rs = new GenResReport();
            rs.Show();
        }

        private void guestServicesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenServicesReport rs = new GenServicesReport();
            rs.Show();
        }

        private void expensesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenExpenseReport rs = new GenExpenseReport();
            rs.Show();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactForm rs = new ContactForm();
            rs.Show();
        }

        private void hotelInternalExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expenditure epe = new Expenditure();
            epe.Show();
        }
    }
}
