using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using testAutoHistory.Models;

namespace testAutoHistory
{
    public partial class Form1 : Form
    {
        UserDbContext _context;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new UserDbContext();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_name.Text))
            {
                _context.Add(new User { name = txt_name.Text });
                _context.SaveChanges();

                txt_name.Text = null;
                MessageBox.Show("등록되었습니다.");
                btn_select_Click(sender, e);
            }
            else
            {
                MessageBox.Show("이름을 입력해주세요.");
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            txt_name.Text = null;
            list_name.Items.Clear();

            if(_context.Users.Count() > 0)
            {
                foreach (User user in _context.Users.ToList())
                {
                    list_name.Items.Add(user.name);
                }
            }
            else
            {
                MessageBox.Show("사용자가 없습니다.");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            if (list_name.SelectedItems.Count > 0)
            {
                if (!String.IsNullOrEmpty(txt_name.Text))
                {
                    
                    var user = _context.Users.Where(x => x.name == list_name.SelectedItems[0].Text).SingleOrDefault();
                    user.name = txt_name.Text;
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    txt_name.Text = null;
                    btn_select_Click(sender, e);
                    MessageBox.Show("수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("수정할 이름을 작성해주세요.");
                    txt_name.Focus();
                }
            }
            else
            {
                MessageBox.Show("이름을 선택해주세요.");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (list_name.SelectedItems.Count > 0)
            {

                var user = _context.Users.Where(x => x.name == list_name.SelectedItems[0].Text).SingleOrDefault();
                _context.Users.Remove(user);
                _context.SaveChanges();

                txt_name.Text = null;
                MessageBox.Show("삭제되었습니다.");
                btn_select_Click(sender, e);
            }
            else
            {
                MessageBox.Show("이름을 선택해주세요.");
            }
        }

        private void list_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(list_name.SelectedItems.Count > 0)
            {
                txt_name.Text = list_name.SelectedItems[0].Text;
            }
        }
    }
}
