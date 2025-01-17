﻿using System;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Monopoly_Project
{
    public partial class host_game_ui : Form
    {
        Storage dataBase;
        public host_game_ui(Storage s)
        {
            dataBase = s;
            InitializeComponent();
        }

        private void host_exit_Click(object sender, EventArgs e)
        {
            playButtonClick();
            this.Hide();
        }

        private async void host_enter_button_Click(object sender, EventArgs e)
        {
            playButtonClick();
            dataBase.hostGame(host_gameID_textbox.Text, host_playerID_textbox.Text);
            await Task.Delay(TimeSpan.FromMilliseconds(300));

            if (dataBase.serverError == false)
            {
                using (game_play_ui gamePlayScreen = new game_play_ui(ref dataBase))
                {
                    this.Hide();
                    this.Owner.Hide();
                    gamePlayScreen.ShowDialog();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bi sıkıntı var hostt", "Paniiik", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
        private void playButtonClick() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(Monopoly_Project.Properties.Resources.button_click); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Play();
        }
    }
}
