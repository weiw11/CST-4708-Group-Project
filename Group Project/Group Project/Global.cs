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

        public static bool login;
        public static AboutUs aboutUs;
        public static ContactUs contactUs;
        public static Registration registration;
        public static Catalog catalog;
        public static Profile profile;
        public static CheckOut checkOut;
        public static Cart cart;

        public static String CONN_STRING
        {
            get { return _CONN_STRING; }
        }

        public static bool ShowLogin()
        {
            _ = new Login
            {
                Visible = true
            };
            login = true;
            Console.WriteLine("Unhiding Login");
            return true;
        }

        public static bool ShowAboutUs()
        {
            aboutUs = new AboutUs();
            aboutUs.Show();
            Console.WriteLine("Showing About Us");
            return true;
        }

        public static bool ShowContactUs()
        {
            contactUs = new ContactUs();
            contactUs.Show();
            Console.WriteLine("Showing Contact Us");
            return true;
        }

        public static bool ShowRegistration()
        {
            registration = new Registration();
            registration.Show();
            Console.WriteLine("Showing Registration");
            return true;
        }

        public static bool ShowCatalog()
        {
            catalog = new Catalog();
            catalog.Show();
            Console.WriteLine("Showing Catalog");
            return true;
        }

        public static bool ShowCatalog(String username)
        {
            catalog = new Catalog(username);
            catalog.Show();
            Console.WriteLine("Showing Catalog");
            return true;
        }

        public static bool ShowProfile(String username)
        {
            profile = new Profile(username);
            profile.Show();
            Console.WriteLine("Showing Profile");
            return true;
        }

        public static bool ShowCheckOut(String username)
        {
            checkOut = new CheckOut(username);
            checkOut.Show();
            Console.WriteLine("Showing CheckOut");
            return true;
        }

        public static bool ShowCart(String username)
        {
            cart = new Cart(username);
            cart.Show();
            Console.WriteLine("Showing Cart");
            return true;
        }

        public static void FormCloseEvent(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    Console.WriteLine("Application exit call");
                    Application.Exit();
                    break;

                case CloseReason.FormOwnerClosing:
                    Console.WriteLine("Form owner closing");
                    Application.Exit();
                    break;

                case CloseReason.MdiFormClosing:
                    Console.WriteLine("Mdi form closing");
                    Application.Exit();
                    break;

                case CloseReason.None:
                    Console.WriteLine("Close reason none");
                    Application.Exit();
                    break;

                case CloseReason.TaskManagerClosing:
                    Console.WriteLine("Task manager closing");
                    Application.Exit();
                    break;

                case CloseReason.UserClosing:
                    Console.WriteLine("User close event");
                    Application.Exit();
                    break;

                case CloseReason.WindowsShutDown:
                    Console.WriteLine("Windows shutdown");
                    Application.Exit();
                    break;

                default:
                    Console.WriteLine("Default closing");
                    Application.Exit();
                    break;
            }
        }
    }
}