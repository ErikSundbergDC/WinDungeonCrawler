﻿using DungeonCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDungeonCrawler
{
    public partial class Form1 : Form
    {

        private PlayerCharacter playerCharacter;
        public Form1()
        {
            InitializeComponent();
        }

        //TODO: Lång och rörig metod. Borde lösas på något annat sätt.
        private static Room CreateWorld()
        {
            Room room1 = new Room("Tamburen", "Det här är rummet direkt innanför ytterdörren. Det står en del möbler och skohyllor här. I den öppna spisen har någon slängt en elscooter.");
            Room room2 = new Room("Korridoren", "En ganska vanlig skolkorridor.");
            Room room3 = new Room("Korridoren utanför toaletterna", "En ganska vanlig skolkorridor.");
            Room room4 = new Room("Korridoren utanför toaletterna", "En ganska vanlig skolkorridor.");
            Room room5 = new Room("En toalett", "En vanlig offentlig toalett. Det är ganska trångt här inne.");
            Room room6 = new Room("En toalett", "En vanlig offentlig toalett. Det är ganska trångt här inne.");
            Room room7 = new Room("En handikapptoalett", "En vanlig offentlig toalett som är anpassad för funktionsvariationer. Det är gott om plats här inne.");
            Room room8 = new Room("Hjärnkontoret höger", "Det här är normalt sett den främre delen av klassrummet. Fast ibland är det den bakre delen.");
            Room room9 = new Room("Hjärnkontoret vänster", "Det här är normalt sett den bakre delen av klassrummet. Fast ibland är det den främre delen.");
            Room room10 = new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här.");
            Room room11 = new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här.");
            Room room12 = new Room("Korridoren", "En ganska vanlig skolkorridor. Det finns elevskåp här.");
            Room room13 = new Room("Ett grupprum", "Här kan elever stänga in sig för att utföra viktigt skolarbete i lugn och ro.");
            Room room14 = new Room("Ett grupprum", "Här kan elever stänga in sig för att utföra viktigt skolarbete i lugn och ro.");
            Room room15 = new Room("Ett arbetsrum", "Här sitter lärarna och softar i lugn och ro.");
            Room room16 = new Room("Inre delen av arbetsrummet", "Här sitter lärarna och softar i lugn och ro.");
            Room room17 = new Room("Ett förråd", "Här förvaras datorprylar.");
            Room room18 = new Room("Ett förråd", "Här förvaras reklammaterial och andra grejer.");

            room1.ExitEast = room2;
            room2.ExitWest = room1;
            room2.ExitEast = room8;
            room2.ExitSouth = room3;
            room2.ExitNorth = room10;
            room3.ExitNorth = room2;
            room3.ExitEast = room5;
            room3.ExitSouth = room4;
            room4.ExitNorth = room3;
            room4.ExitEast = room6;
            room4.ExitWest = room7;
            room5.ExitWest = room3;
            room6.ExitWest = room4;
            room7.ExitEast = room4;
            room8.ExitNorth = room9;
            room8.ExitWest = room2;
            room9.ExitWest = room12;
            room9.ExitSouth = room8;
            room10.ExitNorth = room11;
            room10.ExitSouth = room2;
            room10.ExitWest = room13;
            room11.ExitNorth = room12;
            room11.ExitSouth = room10;
            room11.ExitWest = room14;
            room12.ExitEast = room9;
            room12.ExitSouth = room11;
            room12.ExitWest = room15;
            room13.ExitEast = room10;
            room14.ExitEast = room11;
            room15.ExitNorth = room17;
            room15.ExitEast = room12;
            room15.ExitWest = room16;
            room16.ExitNorth = room18;
            room16.ExitEast = room15;
            room17.ExitSouth = room15;
            room18.ExitSouth = room16;

            NonPlayerCharacter npc1 = new NonPlayerCharacter("Zombien Bob");
            npc1.HealthPoints = 25;
            NonPlayerCharacter npc2 = new NonPlayerCharacter("Spöket Laban");
            npc2.HealthPoints = 3;
            NonPlayerCharacter npc3 = new NonPlayerCharacter("Trollet Göran");
            npc3.HealthPoints = 1000;

            room5.Characters.Add(npc1);
            room5.Characters.Add(npc2);
            room7.Characters.Add(npc3);

            return room1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Room startingRoom = CreateWorld();

            playerCharacter = new PlayerCharacter("Erik");
            playerCharacter.Position = startingRoom;
            playerCharacter.HealthPoints = 100;

            DisplayRoom(playerCharacter.Position);

            
        }

        private void DisplayRoom(Room room)
        {
            textBox1.Clear();
            textBox1.Text = room.Name;
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(room.Description);
            
            if(room.ExitNorth == null)
            {
                buttonNorth.Enabled = false;
            }
            else
            {
                buttonNorth.Enabled = true;
            }
            if (room.ExitEast == null)
            {
                buttonEast.Enabled = false;
            }
            else
            {
                buttonEast.Enabled = true;
            }
            if (room.ExitSouth == null)
            {
                buttonSouth.Enabled = false;
            }
            else
            {
                buttonSouth.Enabled = true;
            }
            if (room.ExitWest == null)
            {
                buttonWest.Enabled = false;
            }
            else
            {
                buttonWest.Enabled = true;
            }

            listBox1.Items.Clear();
            foreach(BaseCharacter character in room.Characters)
            {
                listBox1.Items.Add(character.Name);
            }
            
        }

        private void buttonEast_Click(object sender, EventArgs e)
        {
            playerCharacter.Position = playerCharacter.Position.ExitEast;
            DisplayRoom(playerCharacter.Position);
        }

        private void buttonNorth_Click(object sender, EventArgs e)
        {
            playerCharacter.Position = playerCharacter.Position.ExitNorth;
            DisplayRoom(playerCharacter.Position);
        }

        private void buttonSouth_Click(object sender, EventArgs e)
        {
            playerCharacter.Position = playerCharacter.Position.ExitSouth;
            DisplayRoom(playerCharacter.Position);
        }

        private void buttonWest_Click(object sender, EventArgs e)
        {
            playerCharacter.Position = playerCharacter.Position.ExitWest;
            DisplayRoom(playerCharacter.Position);
        }

        
    }
}
