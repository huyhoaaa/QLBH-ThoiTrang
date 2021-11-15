using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLShopThoiTrang;
using BUS_QLShopThoiTrang;
namespace QLBH_ThoiTrang
{
    public partial class FormQuanLyKhachHang : Form
    {

        public FormQuanLyKhachHang()
        {
            InitializeComponent();
        }
        BUS_KhachHang bus_khachhang = new BUS_KhachHang();
        string email = FormMain.mail;
       public void ResetValue()
        {
            txtDienThoai.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Text = null;
            txtTenKH.Text = null;
            txtDiaChi.Text = null;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            rbNam.Checked = true;
        }
        public void LoadKH()
        {
            dgvKhachHang.DataSource = bus_khachhang.ListKH();
            dgvKhachHang.Columns[0].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
        }
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 1)
            {
                txtDienThoai.Enabled = false;
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                rbNam.Checked = true;               

                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                if ((dgvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString()) == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }
            }
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadKH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            txtDienThoai.Text = null;
            txtDiaChi.Text = null;
            txtTenKH.Text = null;
            rbNam.Checked = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtTenKH.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gioitinh = "Nam";
            if (rbNu.Checked == true)           
                gioitinh = "Nữ";
            
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKH.Text, txtDiaChi.Text, gioitinh,email);
                if (bus_khachhang.ThemKH(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValue();
                    LoadKH();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, lỗi!");
                    ResetValue();
                    LoadKH();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
            }
            else if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string gioitinh = "Nam";
                if (rbNu.Checked == true)
                    gioitinh = "Nữ";
                DTO_KhachHang kh = new DTO_KhachHang(txtDienThoai.Text, txtTenKH.Text, txtDiaChi.Text, gioitinh);

                if (MessageBox.Show("Bạn có muốn chỉnh sửa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bus_khachhang.SuaKH(kh))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadKH();
                        ResetValue();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại! Lỗi");
                        LoadKH();
                    }
                }
                else
                {
                    LoadKH();
                    ResetValue();
                }
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá khách hàng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus_khachhang.XoaKH(txtDienThoai.Text))
                {
                    MessageBox.Show("Xoá thành công");
                    LoadKH();
                    ResetValue();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại! Lỗi kết nối");
                    LoadKH();
                }
            }
            else
            {
                LoadKH();
                ResetValue();
            }
        }
    }
}
