using ReservationApiUygulamasi.UI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationApiUygulamasi.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private Color originalBtnColor;
        private void Login_Load(object sender, EventArgs e)
        {
            originalBtnColor = btnLogin.BackColor;
            btnLogin.FlatAppearance.MouseOverBackColor = originalBtnColor;
            btnLogin.FlatAppearance.MouseDownBackColor = originalBtnColor;
        }
        private HttpClientHandler GetSSL()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
            };
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre giriniz.");
                    return;
                }
                else
                {
                    CurrentUser.username = txtUsername.Text;
                    CurrentUser.password = txtPassword.Text;
                }
                btnLogin.BackColor = originalBtnColor;

                var apiSettings = ConfigurationHelper.LoadApiSettings();

                var httpClient = new HttpClient(GetSSL())
                {
                    BaseAddress = new Uri(apiSettings.BaseUrl),
                    Timeout = TimeSpan.FromSeconds(apiSettings.Timeout)
                };

                var tokenService = new TokenService(httpClient);

                var token = await tokenService.GetTokenAsync(txtUsername.Text, txtPassword.Text);

                if (!string.IsNullOrEmpty(token))
                {
                    ConfigurationHelper.UpdateToken(token);
                    try
                    {
                        try
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                            var response = await httpClient.GetAsync("api/Users");
                            if (response.IsSuccessStatusCode)
                            {
                                var json = await response.Content.ReadAsStringAsync();

                                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);

                                var currentUser = users.FirstOrDefault(u => string.Equals(u.username, txtUsername.Text, StringComparison.Ordinal) && string.Equals(u.password, txtPassword.Text, StringComparison.Ordinal));




                                if (currentUser != null)
                                {
                                    CurrentUser.UserID = currentUser.ID;
                                    CurrentUser.username = currentUser.username;


                                    btnLogin.BackColor = Color.Green;
                                    await Task.Delay(300);
                                }
                                else
                                {
                                    btnLogin.BackColor = Color.Red;
                                    MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                                    btnLogin.BackColor = originalBtnColor;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcılar API'sinden veri alınamadı.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("User çekme hatası: " + ex.Message);
                        }

                    }
                    catch
                    {}

                    FrmSelection frm = new FrmSelection();
                    frm.Show();
                    this.Hide();
                }
                else
                {

                    btnLogin.BackColor = Color.Red;
                    MessageBox.Show("Token alınamadı.");
                    btnLogin.BackColor = originalBtnColor;
                }
            }
            catch (Exception ex)
            {
                btnLogin.BackColor = Color.Red;
                MessageBox.Show("Giriş başarısız: " + ex.Message);
                btnLogin.BackColor = originalBtnColor;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}