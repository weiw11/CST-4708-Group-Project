using System;
using System.Windows.Forms;

namespace Group_Project
{
    internal class Global
    {
        private readonly static String _CONN_STRING =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "" +
            "|DataDirectory|\\Comics.mdf" +
            ";Integrated Security=True;Connect Timeout=30";

        public static String CONN_STRING
        {
            get { return _CONN_STRING; }
        }

        public static void ShowLogin()
        {
            _ = new Login
            {
                Visible = true
            };
            Console.WriteLine("Unhiding Login");
        }

        public static void ShowAboutUs()
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.Show();
            Console.WriteLine("Showing About Us");
        }

        public static void ShowContactUs()
        {
            ContactUs contactUs = new ContactUs();
            contactUs.Show();
            Console.WriteLine("Showing Contact Us");
        }

        public static void ShowRegistration()
        {
            Registration registration = new Registration();
            registration.Show();
            Console.WriteLine("Showing Registration");
        }

        public static void ShowCatalog()
        {
            Catalog catalog = new Catalog();
            catalog.Show();
            Console.WriteLine("Showing Catalog");
        }

        public static void ShowCatalog(String username)
        {
            Catalog catalog = new Catalog(username);
            catalog.Show();
            Console.WriteLine("Showing Catalog");
        }

        public static void ShowProfile(String username)
        {
            Profile profile = new Profile(username);
            profile.Show();
            Console.WriteLine("Showing Profile");
        }

        public static void ShowCheckOut(String username)
        {
            CheckOut checkOut = new CheckOut(username);
            checkOut.Show();
            Console.WriteLine("Showing CheckOut");
        }
        public static void ShowCart(String username)
        {
            Cart cart = new Cart(username);
            cart.Show();
            Console.WriteLine("Showing Cart");
        }

        public static void FormCloseEVent(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    Application.Exit();
                    break;

                case CloseReason.FormOwnerClosing:
                    Application.Exit();
                    break;

                case CloseReason.MdiFormClosing:
                    Application.Exit();
                    break;

                case CloseReason.None:
                    Application.Exit();
                    break;

                case CloseReason.TaskManagerClosing:
                    Application.Exit();
                    break;

                case CloseReason.UserClosing:

                    // User close event
                    break;

                case CloseReason.WindowsShutDown:
                    Application.Exit();
                    break;

                default:
                    Application.Exit();
                    break;
            }
        }
    }
}