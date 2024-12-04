using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVN_Tuan4
{
    public partial class form1 : Form
    {
        List<NhanVien> nhanViens;
        public delegate void PassDataDelegate(NhanVien nhanVien);

        public form1()
        {
            InitializeComponent();
        }
        private void form1_Load(object sender, EventArgs e)
        {
            nhanViens = new List<NhanVien>();
            nhanViens.Add(new NhanVien() { MSNV = 1, TenNV = "A", LuongCB = 5000000 });
            nhanViens.Add(new NhanVien() { MSNV = 2, TenNV = "B", LuongCB = 6000000 });
            nhanViens.Add(new NhanVien() { MSNV = 3, TenNV = "C", LuongCB = 4500000 });
            nhanViens.Add(new NhanVien() { MSNV = 4, TenNV = "D", LuongCB = 7000000 });

            // Gán dữ liệu cho DataGridView
            datainfo.DataSource = new BindingList<NhanVien>(nhanViens);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(null);
            PassDataDelegate passData = new PassDataDelegate(AddNhanVien);
            frm.passDataDelegate = passData;
            frm.ShowDialog();
        }
        private void AddNhanVien(NhanVien nhanVien)
        {
            nhanViens.Add(nhanVien);
            datainfo.DataSource = null;
            datainfo.DataSource = new BindingList<NhanVien>(nhanViens);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (datainfo.SelectedRows.Count > 0)
            {
                int index = datainfo.SelectedRows[0].Index;
                NhanVien nv = nhanViens[index];

                Form2 frm = new Form2(nv);
                PassDataDelegate passData = new PassDataDelegate((updatedNhanVien) =>
                {
                    nhanViens[index] = updatedNhanVien;
                    datainfo.DataSource = null;
                    datainfo.DataSource = new BindingList<NhanVien>(nhanViens);
                });

                frm.passDataDelegate = passData;
                frm.ShowDialog();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (datainfo.SelectedRows.Count > 0)
            {
                int index = datainfo.SelectedRows[0].Index;
                nhanViens.RemoveAt(index);
                datainfo.DataSource = null;
                datainfo.DataSource = new BindingList<NhanVien>(nhanViens);
            }
        }

        private void txtDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

