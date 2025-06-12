using System;

private void button1_Click(object sender, EventArgs e)
{
    int input;
    if (int.TryParse(textBox1.Text, out input))
    {
        label1.Text = CariTandaBilangan(input);
    }
    else
    {
        label1.Text = "Input tidak valid!";
    }
}
