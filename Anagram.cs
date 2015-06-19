private void openToolStripMenuItem_Click(object sender, EventArgs e)
{
    string strOpenFilename, strInputText, strAnagramWord;
    if (openFileDialog1.ShowDialog() == DialogResult.OK) 
    {
        strOpenFilename = openFileDialog1.FileName;
        StreamReader srFileReader = new StreamReader(strOpenFilename);
        strInputText = srFileReader.ReadToEnd();
        srFileReader.Close();
        strAnagramWord = txtInitial.Text;
        strInputText = strInputText.ToUpper();
        strInputText = strInputText.Replace(",","");
        strInputText = strInputText.Replace(".", "");
        strInputText = strInputText.Replace("?", "");
        strInputText = strInputText.Replace("!", "");
        strInputText = strInputText.Replace(";", "");
        strAnagramWord = strAnagramWord.ToUpper();

        char[] chr_AnagramWord = strAnagramWord.ToCharArray();
        Array.Sort(chr_AnagramWord);
        string strAnagramSorted = new string(chr_AnagramWord);

        string[] separated = strInputText.Split(' ');
        int int_No_Anagrams = 0;
        for (int i = 0; i < separated.Length; i++ ) 
        {
            if (strAnagramSorted.Length == separated[i].Length) 
            {
                char[] chr_OneWord = separated[i].ToCharArray();
                Array.Sort(chr_OneWord);
                string strOneWordSorted = new string(chr_OneWord);
                // MessageBox.Show(strOneWordSorted);
                if (strAnagramSorted == strOneWordSorted) int_No_Anagrams++;
            }
        }
        MessageBox.Show(int_No_Anagrams.ToString(), "There are anagrams of");
    }
}
