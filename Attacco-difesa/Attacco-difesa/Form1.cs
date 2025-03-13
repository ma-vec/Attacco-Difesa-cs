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
        bool ready = false; //definisce quando i giocatori sono pronti acombattere
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
                ready = true;
                Thread trdDif = new Thread(() => FightTread());
                trdDif.Start();
            }
            UpdateListBox();
            
        }

        private void FightTread()
        {
            if(ready) {
            if (listaAttaccanti.Count >=1 && listaDifensori.Count >=1)
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
                    
                    //Inizia combattimento
                    labelName1.Text = listaAttaccanti[0].Id.ToString() + $" (Attacco: {listaAttaccanti[0].PtDannoAttacco.ToString()} pt, Difesa: {listaAttaccanti[0].PercDif.ToString()}%)";
                    labelName2.Text = listaDifensori[0].Id.ToString() + $" (Attacco: {listaDifensori[0].PtDannoAttacco.ToString()} pt, Difesa: {listaDifensori[0].PercDif.ToString()}%)";
                    });
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
            else
            {
                MessageBox.Show("Sono rimasti in vita " + listaAttaccanti.Count.ToString() + "e " + listaDifensori.Count.ToString() + " difensori");
            }
           }
        }

        private void IniziaCombattimento(Gamer G1, Gamer G2)
        {
            while (G1.PuntiFerita > 0 && G2.PuntiFerita > 0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    progressBarG1.Value = G1.PuntiFerita;
                    labelFerita1.Text = G1.PuntiFerita.ToString();
                    progressBarG2.Value = G2.PuntiFerita;
                    labelFerita2.Text = G2.PuntiFerita.ToString();

                    if (G1.IsFighter) { labelRole1.Text = "Attaccante"; } else { labelRole1.Text = "Difensore"; };
                    if (G2.IsFighter) { labelRole2.Text = "Attaccante"; } else { labelRole2.Text = "Difensore"; };
                });

                if (G1.IsFighter)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelAtt1.Text = G1.Attacca(G2).ToString()+"%";
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelAtt2.Text = G2.Attacca(G1).ToString() + "%";
                    });
                }

                G1.SwitchRole();
                G2.SwitchRole();
                Thread.Sleep(1000);
            }

            this.Invoke((MethodInvoker)delegate
            {
                if (G1.PuntiFerita <= 0)
                {
                    listaAttaccanti.Remove(G1);
                    MessageBox.Show($"Vittoria di {G2.Id}");
                }
                else
                {
                    listaDifensori.Remove(G2);
                    MessageBox.Show($"Vittoria di {G1.Id}");
                }
                UpdateListBox();
            });
        }

    }
}

