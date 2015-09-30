using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectMiraiDXSE_GUI
{
    public partial class MainForm : Form
    {
        //Easy Button High Score Offset: 0x04
        //Easy Button Percentage Offset: 0x08
        //Easy Button Second Rank Offset: 0x0c
        //Easy Button Combo Offset: 0x0a
        //Normal Button First Rank Offset: 0x10
        //Normal Button High Score Offset: 0x14
        //Normal Button Percentage Offset: 0x18
        //Normal Button Second Rank Offset: 0x1c
        //Normal Button Combo Offset: 0x1a
        //Hard Button First Rank Offset: 0x20
        //Hard Button High Score Offset: 0x24
        //Hard Button Percentage Offset: 0x28
        //Hard Button Second Rank Offset: 0x2c
        //Hard Button Combo Offset: 0x2a

        //Easy Touch First Rank Offset: 0x40
        //Easy Touch High Score Offset: 0x44
        //Easy Touch Percentage Offset: 0x48
        //Easy Touch Second Rank Offset: 0x4c
        //Easy Touch Combo Offset: 0x4a
        //Normal Touch First Rank Offset: 0x50
        //Normal Touch High Score Offset: 0x54
        //Normal Touch Percentage Offset: 0x58
        //Normal Touch Second Rank Offset: 0x5c
        //Normal Touch Combo Offset: 0x5a
        //Hard Touch First Rank Offset: 0x60
        //Hard Touch High Score Offset: 0x64
        //Hard Touch Percentage Offset: 0x68
        //Hard Touch Second Rank Offset: 0x6c
        //Hard Touch Combo Offset: 0x6a

        //Unlock Song Offset: 0x98

        string save = "bk_m2r.bin";

        private int MaxMP = 0x0008;
        private int AgentMoose = 0x98;
        private int deathwilldie = 0x20;
        private int SpankrPoodle = 0x40;
        private int SpankrPoodle2 = 0x50;
        private int Wrench_King = 0x00;
        private int Nirvash_TypeZero = 0x0c;
        private int Badger41 = 0x10;
        private int sKiLLz = 0x1c;
        private int reDFlag = 0x2c;
        private int Vernon = 0x40;
        private int eYeDoL = 0x4c;
        private int destructo = 0x5c;
        private int A051019194709_1 = 0x6c;
        private int A051019194709_2 = 0x60;

        //===================

        //Songs offsets
        private int[] Songs =
        {
            0x2750, 0x2848, 0x2940, 0x2A38, 0x2B30, 0x2C28, 0x2D20, 0x2E18, 0x2F10, 0x3008, 0x3100, 0x31F8, 0x32F0, 0x33E8,
            0x34E0, 0x35D8, 0x36D0, 0x37C8, 0x38C0, 0x39B8, 0x3AB0, 0x3BA8, 0x3CA0, 0x3D98, 0x3E90, 0x3F88, 0x4080, 0x4178,
            0x4270, 0x4368, 0x4460, 0x4558, 0x4650, 0x4748, 0x4840, 0x4938, 0x4A30, 0x4B28, 0x4C20, 0x4D18, 0x4E10, 0x4F08,
            0x5000, 0x50F8, 0x51F0, 0x52E8, 0x53E0, 0x54D8, 0x55D0
        };

        //First List in each list are the items that can be unlocked
        //Second List in each list are each items in that catagory

        //Small Items
        private int[][] SmallItems = new int[][]
        {
            new int[] { 0x6a28, 0x6a40, 0x6a48, 0x6a58, 0x6a60, 0x6a78, 0x6a88, 0x6a90, 0x6ac8, 0x6ad0, 0x6ad8, 0x6af0, 0x6af8 },

            new int[] { 0x69c0, 0x69c8, 0x69d0, 0x69d8, 0x69e0, 0x69e8, 0x69f0, 0x69f8, 0x6a00, 0x6a08, 0x6a10, 0x6a18, 0x6a20,
                        0x6a28, 0x6a30, 0x6a38, 0x6a40, 0x6a48, 0x6a50, 0x6a58, 0x6a60, 0x6a68, 0x6a70, 0x6a78, 0x6a80, 0x6a88,
                        0x6a90, 0x6a98, 0x6aa0, 0x6aa8, 0x6ab0, 0x6ab8, 0x6ac0, 0x6ac8, 0x6ad0, 0x6ad8, 0x6ae0, 0x6ae8, 0x6af0,
                        0x6af8, 0x6b00 }
        };

        //Medium Items
        private int[][] MediumItems = new int[][]
        {
            new int[] { 0x6bd8, 0x6c10, 0x6c80 },
            new int[] { 0x6b50, 0x6B58, 0x6B60, 0x6B68, 0x6B70, 0x6B78, 0x6B80, 0x6B88, 0x6B88,
                        0x6B98, 0x6BA0, 0x6BA8, 0x6BB0, 0x6BB8, 0x6BC0, 0x6BC8, 0x6BD0, 0x6BD8,
                        0x6BE0, 0x6BE8, 0x6BF0, 0x6BF8, 0x6C00, 0x6C08, 0x6C10, 0x6C18, 0x6C20,
                        0x6C28, 0x6C30, 0x6C38, 0x6C40, 0x6C48, 0x6C50, 0x6C58, 0x6C60, 0x6C68,
                        0x6C70, 0x6C78, 0x6c80 }
        };

        //Large Items
        private int[][] LargeItems = new int[][]
        {
            new int[] { 0x6d38 },

            new int[] { 0x6CE0, 0x6CE8, 0x6CF0, 0x6CF8, 0x6D00, 0x6D08, 0x6D10, 0x6D18, 0x6D20, 0x6D28, 0x6D30, 0x6D38 }
        };

        //Wall Items
        private int[] WallItems =
        {
            0x6D80, 0x6D88, 0x6D90, 0x6D98, 0x6DA0, 0x6DA8, 0x6DB0, 0x6DB8, 0x6DC0,
            0x6DC8, 0x6DD0, 0x6DD8, 0x6DE0, 0x6DE8, 0x6DF0, 0x6DF8, 0x6E00, 0x6E08, 0x6E10
        };

        //Air Items
        private int[][] AirItems = new int[][] { new int[] { 0x6e90 }, new int[] { 0x6e70, 0x6e78, 0x6e80, 0x6e88, 0x6e90 }};

        //Pool Items
        private int[] PoolItems = { 0x6EC0, 0x6EC8, 0x6ED0, 0x6ED8 };

        //Outfits
        private int[] Outfits =
        {
            0x56c8, 0x56E8, 0x5708, 0x5728, 0x5748, 0x5768, 0x5788, 0x57A8, 0x57C8, 0x57E8,
            0x5808, 0x5828, 0x5848, 0x5868, 0x5888, 0x58A8, 0x58C8, 0x58E8, 0x5908, 0x5928,
            0x5948, 0x5968, 0x5988, 0x59A8, 0x59C8, 0x59E8, 0x5A08, 0x5A28, 0x5A48, 0x5A68,
            0x5A88, 0x5AA8, 0x5AC8, 0x5AE8, 0x5B08, 0x5B28, 0x5B48, 0x5B68, 0x5B88, 0x5BA8,
            0x5BC8, 0x5C08, 0x5C28, 0x5C48, 0x5C68, 0x5C88, 0x5CA8, 0x5CC8, 0x5CE8, 0x5D08,
            0x5D28, 0x5D48, 0x5D68, 0x5D88, 0x5DA8, 0x5DC8, 0x5DE8, 0x5E08, 0x5E28, 0x5E48,
            0x5E68, 0x5E88, 0x5EA8, 0x5EC8, 0x5EE8, 0x5F08, 0x5F28, 0x5F48, 0x5F68, 0x5F88,
            0x5FC8, 0x5FE8, 0x6008, 0x6028, 0x6048, 0x6068, 0x6088, 0x60A8, 0x60C8, 0x6108,
            0x6128, 0x6148, 0x6168, 0x6188, 0x61A8, 0x61C8, 0x61E8, 0x6228, 0x6248, 0x6268,
            0x6288, 0x62A8, 0x62C8, 0x62E8, 0x6328, 0x6348, 0x6368, 0x6388, 0x63A8, 0x63C8,
            0x63E8, 0x6408, 0x6428, 0x6468, 0x6488, 0x64A8, 0x64C8, 0x64E8, 0x6508, 0x6548,
            0x6568, 0x6588, 0x65A8, 0x65C8, 0x65E8, 0x6608, 0x6628, 0x6648, 0x6668, 0x6688
        };

        //===================

        public MainForm()
        {
            InitializeComponent();

            //Disable Not Implemented Command Buttons - remove once implemented
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            //===================
            if (!File.Exists("bk_m2r.bin"))
            {
                MessageBox.Show("bk_m2r.bin save file not found! Please place it in this folder and restart the program.", "ERROR File Missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        //About Button
        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This save editor is based on the Python Script by Agent Moose @ GBATEMP." + Environment.NewLine + Environment.NewLine + "C# Version by Shadowtrance with assistance from DaBlackDeath.", "ABOUT");
        }

        //Write changes to save file
        private void Unlock(int offset, byte[] value)
        {
            FileStream miraiFS = new FileStream(save, FileMode.Open);
            BinaryWriter miraiBR = new BinaryWriter(miraiFS);
            miraiFS.Position = offset;
            miraiBR.Write(value);
            miraiFS.Close();
        }

        //MouseEnter button colour change to lime
        private void forAllButtons_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Lime;
        }

        //MouseLeave button colour change to transparent
        private void forAllButtons_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Transparent;
        }

        //===================

        //Max MP (992244)
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] value = { 0xf2, 0x3f, 0x40, 0x00 };
            Unlock(MaxMP, value);
            MessageBox.Show("MP Set to Max with no overflow! (992244)", "DONE");
        }

        //Unlock All Songs
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] value = { 0xA0 };
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + AgentMoose, value);
            }
            MessageBox.Show("All 48 Songs Unlocked!", "DONE");
        }

        //Unlock Hard
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] value = { 0x01 };
            foreach (var Song_offset in Songs)
            {
                //Unlock All Hard Button
                Unlock(Song_offset + deathwilldie, value);
            }
            foreach (var Song_offset in Songs)
            {
                //Unlock All Hard Touch
                Unlock(Song_offset + SpankrPoodle, value);
            }
            MessageBox.Show("All Hard Mode difficulties Unlocked!", "DONE");
        }

        //Unlock Items
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] value = { 0x03 };
            foreach (var items in SmallItems[0])
            {
                //Unlock All Small Items in Shop
                Unlock(items, value);
            }
            foreach (var items in MediumItems[0])
            {
                //Unlock All Medium Items in Shop
                Unlock(items, value);
            }
            foreach (var items in LargeItems[0])
            {
                //Unlock All Large Items in Shop
                Unlock(items, value);
            }
            foreach (var items in AirItems[0])
            {
                //Unlock all Air Items in Shop
                Unlock(items, value);
            }
            MessageBox.Show("All Room Items in the shop Unlocked, but not paid for.", "DONE");
        }

        //Unlock Outfits
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] value = { 0x03 };
            foreach (var outfits in Outfits)
            {
                //Unlock all Outfits in Shop
                Unlock(outfits, value);
            }
            MessageBox.Show("All Outfits in the shop Unlocked, but not paid for.", "DONE");
        }

        //Perfect
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] value1 = { 0xAA };
            byte[] value2 = { 0x05 };
            byte[] value3 = { 0x00 };

            //Perfect Each Song
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + AgentMoose, value1);
            }
            //All Easy Button Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + Wrench_King, value2);
            }
            //All Easy Button Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + Nirvash_TypeZero, value3);
            }
            //All Normal Button Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + Badger41, value2);
            }
            //All Normal Button Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + sKiLLz, value3);
            }
            //All Hard Button Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + deathwilldie, value2);
            }
            //All Hard Button Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + reDFlag, value3);
            }
            //All Easy Touch Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + Vernon, value2);
            }
            //All Easy Touch Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + eYeDoL, value3);
            }
            //All Normal Touch Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + SpankrPoodle2, value2);
            }
            //All Normal Touch Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + destructo, value3);
            }
            //All Hard Touch Rank = Perfect
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + A051019194709_2, value2);
            }
            //All Normal Touch Second Rank = S+
            foreach (var Song_offset in Songs)
            {
                Unlock(Song_offset + A051019194709_1, value3);
            }
            //Buy All Small Items in Shop
            foreach (var items in SmallItems[1])
            {
                Unlock(items, value2);
            }
            //Buy All Medium Items in Shop
            foreach (var items in MediumItems[1])
            {
                Unlock(items, value2);
            }
            //Buy All Large Items in Shop
            foreach (var items in LargeItems[1])
            {
                Unlock(items, value2);
            }
            //Buy All Wall Items in Shop
            foreach (var items in WallItems)
            {
                Unlock(items, value2);
            }
            //Buy all Air Items in Shop
            foreach (var items in AirItems[1])
            {
                Unlock(items, value2);
            }
            //Buy all Pool Items in Shop
            foreach (var items in PoolItems)
            {
                Unlock(items, value2);
            }
            //Buy all Outfits
            foreach (var outfits in Outfits)
            {
                Unlock(outfits, value2);
            }
            MessageBox.Show("All Songs Unlocked and Perfect Rank!" + Environment.NewLine + "All Room Items in the shop unlocked and paid for!" + Environment.NewLine + "All Outfits in the shop unlocked and paid for!" + Environment.NewLine + "All done, you cheater. ;)", "DONE");
        }

        //===================NOT IMPLEMENTED YET
        //Max Snacks
        private void button7_Click(object sender, EventArgs e)
        {

        }

        //All Songs Max MP
        private void button8_Click(object sender, EventArgs e)
        {

        }

        //All Songs 100%
        private void button9_Click(object sender, EventArgs e)
        {

        }

        //All Songs Max Combo
        private void button10_Click(object sender, EventArgs e)
        {

        }

        //Unlock All Stamps
        private void button11_Click(object sender, EventArgs e)
        {

        }

        //===================
    }
}
