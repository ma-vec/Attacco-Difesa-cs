namespace Attacco_difesa
{
    public partial class Form1 : Form
    {
        const int numGamers = 10;
        Random random = new Random();
        List<Gamer> listaAttaccanti = new List<Gamer>();
        List<Gamer> listaDifensori = new List<Gamer>();
        SemaphoreSlim SemaphoreAttaccanti = new SemaphoreSlim(1);
        SemaphoreSlim SemaphoreDifensori = new SemaphoreSlim(1);
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateListBox()
        {
            listBoxAttaccanti.DataSource = null;
            listBoxAttaccanti.DataSource = listaAttaccanti;
            listBoxAttaccanti.DisplayMember = "Id";
            listBoxDifensori.DataSource = null;
            listBoxDifensori.DataSource = listaDifensori;
            listBoxDifensori.DisplayMember = "Id";
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
                Gamer attaccante = new Gamer("F"+id.ToString(), true, randomPtiFerita, randomPtiAttacco, RandomPercDif);
                id++;
                listaAttaccanti.Add(attaccante);
                Thread trdAtt = new Thread(() => FightTread());
                trdAtt.Start();

            }
            id = 0;
            for (int i = 0; i < numGamers / 2; i++)
            {
                int randomPtiFerita = random.Next(200, 501);
                int randomPtiAttacco = random.Next(10, 201);
                int RandomPercDif = random.Next(10, 101);
                Gamer difensore = new Gamer("D"+id.ToString(), false, randomPtiFerita, randomPtiAttacco, RandomPercDif);
                id++;
                listaDifensori.Add(difensore);
                Thread trdDif = new Thread(() => FightTread());
                trdDif.Start();
            }
            UpdateListBox();
        }

        private void FightTread()
        {
            try
            {
                //Trova i due giocatori
                SemaphoreAttaccanti.Wait();
                SemaphoreDifensori.Wait();
                this.Invoke((MethodInvoker)delegate
                {
                    progressBarG1.Maximum = listaAttaccanti[0].PuntiFerita;
                    progressBarG2.Maximum = listaDifensori[0].PuntiFerita;
                });
                //Inizia combattimento
                IniziaCombattimento(listaAttaccanti[0], listaDifensori[0]);
            }
            catch (Exception ex)
            {
                // Gestione di eccezioni non previste
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Errore: {ex.Message}");
                });
            }
            finally
            {
                SemaphoreDifensori.Release();
                SemaphoreAttaccanti.Release();
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateListBox();
                });
            }
        }

        private void IniziaCombattimento(Gamer G1, Gamer G2)
        {
            while (G1.PuntiFerita > 0 && G2.PuntiFerita > 0)
            {
                int percSingoloAttacco = random.Next(1, 101); //perc. casuale per ogni attacco
                this.Invoke((MethodInvoker)delegate
                {
                    //MessageBox.Show(G1.PuntiFerita.ToString(), G2.PuntiFerita.ToString());
                    progressBarG1.Value = G1.PuntiFerita;
                    labelFerita1.Text = G1.PuntiFerita.ToString();
                    progressBarG2.Value = G2.PuntiFerita;
                    labelFerita2.Text = G2.PuntiFerita.ToString();
                    labelName1.Text = percSingoloAttacco.ToString();
                    if (G1.IsFighter) labelRole1.Text = "Attacante"; else labelRole1.Text = "Difensore";
                    if (G2.IsFighter) labelRole2.Text = "Attacante"; else labelRole2.Text = "Difensore";
                });

                

                if (G1.IsFighter == G2.IsFighter)
                    G1.SwitchRole(); //se per errore hanno stesso ruolo, viene cambiato solo uno

                //identifica l'attacante
                if (G1.IsFighter)
                {
                    G1.Attacca(percSingoloAttacco, G2);
                }
                else if (G2.IsFighter)
                {
                    G2.Attacca(percSingoloAttacco, G1);
                }
                G1.SwitchRole();
                G2.SwitchRole();

            } //Combattimento terminato
            if(G1.PuntiFerita<=0)
            {
                listaAttaccanti.RemoveAt(0);
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Vittoria G 2");
                    UpdateListBox();
                    
                });
            } else if(G2.PuntiFerita<=0)
            {
                listaDifensori.RemoveAt(0);
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Vittoria G 1");
                    UpdateListBox();

                });
            }
        }
    }
}
