using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BTVN_Tuan4.form1;

namespace BTVN_Tuan4
{
    public partial class Form2 : Form
    {
        public PassDataDelegate passDataDelegate;

        public Form2(NhanVien nhanVien)
        {
            InitializeComponent();
            if (nhanVien != null)
            {
                txtMSNV.Text = nhanVien.MSNV.ToString();
                txtTenNV.Text = nhanVien.TenNV;
                txtLuongCB.Text = nhanVien.LuongCB.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nhanVien = new NhanVien
                {
                    MSNV = int.Parse(txtMSNV.Text),
                    TenNV = txtTenNV.Text,
                    LuongCB = decimal.Parse(txtLuongCB.Text)
                };

                passDataDelegate?.Invoke(nhanVien);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
