namespace Attacco_difesa
{
    public partial class Form1 : Form
    {
        const int numGamers = 10;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            //crea i giocatori
            for(int i =0; i<numGamers/2; i++)
            {
                int randomPtiFerita = random.Next(200, 501);
                int randomPtiAttacco = random.Next(10, 201);
                int RandomPercDif = random.Next(10, 101);
                Gamer attaccante = new Gamer(id, true, randomPtiFerita, randomPtiAttacco, RandomPercDif);
                id++;
                //inserire in lista
            }
            id = 0;
            for (int i = 0; i < numGamers / 2; i++)
            {
                int randomPtiFerita = random.Next(200, 501);
                int randomPtiAttacco = random.Next(10, 201);
                int RandomPercDif = random.Next(10, 101);
                Gamer attaccante = new Gamer(id, false, randomPtiFerita, randomPtiAttacco, RandomPercDif);
                id++;
                //inserire in lista
            }
        }
    }
}
