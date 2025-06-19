using System.DirectoryServices.ActiveDirectory;
using System.Linq.Expressions;

namespace My_Math_Game_1
{
    public partial class Form1 : Form
    {//Input
        Random seed = new Random();//Generate a Random Number 
        int Total; //global variables total 
        int Correct; //global variables correct answer  
        int Attempts; //global variables attempt 
        //global variables means all these variable are integers 
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_question_Click(object sender, EventArgs e)//Make a Question button
        {
          
                welldoneBox.Visible = false; //Correct Green tick picturebox resets once make a question button is clicked
                lblanswer.Visible = false; //Correct Answer resets once make a question button is clicked 
                int Num1 = seed.Next(10) + 1; //Declared Num1 variable as a random number between 1 and 10 (C# counts from 0 so add 1) 
                int Num2 = seed.Next(10) + 1; //Declared Num2 variable as a random number between 1 and 10 (C# counts from 0 so add 1)
                int Num3 = seed.Next(10) + 1; //Declared Num3 variable as a random number between 1 and 10 (C# counts from 0 so add 1)

                lblone.Text = Num1.ToString(); //First random number displays in the First label 
                lbltwo.Text = Num2.ToString(); //Second random number displays in the Second label 
                lblthree.Text = Num3.ToString(); //Third random number displays in the Third label 

                pBox1.Image = Image.FromFile("Num" + Num1.ToString() + ".jpg"); //First picturebox shows corresponding image to number
                pBox2.Image = Image.FromFile("Num" + Num2.ToString() + ".jpg"); //Second Picturebox shows corresponding image to number
                pBox3.Image = Image.FromFile("Num" + Num3.ToString() + ".jpg"); //Third Picturebox shows corresponding image to number
                txtAnswer.Text = null; //Clears answer box once make a question button is clicked  
                txtAnswer.ReadOnly = false; //Read only to protect answer 

                Total = Num1 + (Num2 * Num3); //Process: Total calculation of the three numbers in the correct mathematical sequence  
            }

      
        private void btn_answer_Click(object sender, EventArgs e)//Process: Check my Answer 
        {
            try
            {
                int playertry = Convert.ToInt32(txtAnswer.Text); //Input: User inputs answer in textbox and is converted to integer  
                {
                    Attempts += 1; //As per C# counts start from zero
                    lbltried.Text = "" + Attempts; //Output: Counts every attempt user inputs an answer "Total Times tried:"  
                }
            
                if (Total <= 2 || Total >= 110) //if statement explaining if user input number less than 2 or greater than 110
            {
                MessageBox.Show("Outside range of sum"); //Messagebox to show user number entered is outside of range 
            }
            if (playertry == Total) //If user input answer is equvalent to total indicating correct answer  
                {
                    Correct += 1;//As per C# correct score count starting from zero
                    lbltimes.Text = "" + Correct; //Output: Counts every time user input answer is correct "Correct Answer Times"
                    welldoneBox.Visible = true; //Output: Picturebox is now visible 
                    welldoneBox.Image = Image.FromFile("welldone.jfif");//Output: Shows image of the green tick when answer is correct 
                    txtAnswer.ReadOnly = true; //Unable to alter textbox answer to establish user to make a new question 
                    lblanswer.Visible = true; //Output: Shows correct answer behind question mark label
                    lblanswer.Text = Total.ToString(); //Question mark label will show the total once correct  
                }
                else
                {
                    MessageBox.Show("Oops! Try again");//Output: If answer is incorrect then Message Box pops up saying try again 
                }
            }
            catch (Exception) //alternative expression 
            {
                MessageBox.Show("Please use numbers only");//Output: if letters or symbol entered then message box pops up
            }
        }
    }
}