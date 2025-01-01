using System;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
    private TextBox textBox;
    private Label label;
    private Label label2;

    // Variables for dragging
    private bool isDragging = false;
    private int mouseX, mouseY;

    public MyForm()
    {
        // Set the form's size
        this.Width = 250;
        this.Height = 105;

        // Remove maximize, minimize, and close buttons
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = false;

        // Make the form close only on double-click
        this.MouseDoubleClick += (sender, e) => this.Close();

        // Position the form near the taskbar
        PositionFormNearTaskbar();

        // Create the TextBox
        textBox = new TextBox();
        textBox.Width = this.ClientSize.Width - 10;  // Form width minus padding
        textBox.Location = new Point(5, 5);  // Padding of 5px from left and top
        textBox.TextChanged += TextBox_TextChanged; // Event handler for text change
        this.Controls.Add(textBox);

        // Create the Label
        label = new Label();
        label.Width = this.ClientSize.Width - 10; // Same width as TextBox
        label.Location = new Point(5, textBox.Bottom + 5); // Place it below the TextBox
        label.Text = "Enter an epoch time.";  // Initial text
        label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
        this.Controls.Add(label);

        // Create the Label2
        label2 = new Label();
        label2.Width = this.ClientSize.Width - 10; // Same width as TextBox
        label2.Location = new Point(5, label.Bottom); // Place it below the TextBox
        label2.Text = "";  // Initial text
        label2.Font = new Font(Label.DefaultFont, FontStyle.Bold);
        this.Controls.Add(label2);

        // Event handlers for dragging the form
        this.MouseDown += Form_MouseDown;
        this.MouseMove += Form_MouseMove;
        this.MouseUp += Form_MouseUp;
    }

    private void PositionFormNearTaskbar()
    {
        // Get the working area of the primary screen (excludes taskbar)
        Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

        // Calculate the center-bottom position
        int x = workingArea.Width - this.Width - 75; // Center horizontally
        int y = workingArea.Bottom - this.Height - 75; // Position slightly above the taskbar

        // Set the form's start position and location
        this.StartPosition = FormStartPosition.Manual;
        this.Location = new Point(x, y);
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        string input = textBox.Text;

        // Try to parse the input as an EPOCH time
        if (long.TryParse(input, out long epochTime))
        {
            try
            {
                DateTimeOffset dateTime = DateTimeOffset.FromUnixTimeSeconds(epochTime);
                label.Text = dateTime.ToLocalTime().ToString("ddd dd-MMM-yyyy HH:mm:ss") + " (Local)";
                label2.Text = dateTime.ToString("ddd dd-MMM-yyyy HH:mm:ss") + " UTC";  
            }
            catch (Exception)
            {
                label.Text = "Invalid epoch time.";
                label2.Text = "";
            }
        }
        else
        {
            label.Text = "Invalid epoch time.";
            label2.Text = "";
        }
    }

    private void Form_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            mouseX = e.X;
            mouseY = e.Y;
        }
    }

    private void Form_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            this.Left = this.Left + (e.X - mouseX);
            this.Top = this.Top + (e.Y - mouseY);
        }
    }

    private void Form_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }

    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyForm());
    }
}
