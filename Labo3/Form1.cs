using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//1 Vecteur d'initialisation et son rôle
//Le vecteur d'initialisation est un paramètre utilisé dans les
//algorithmes de chiffrement symétrique pour initialiser l'état du chiffrement.
//Il permet de rendre unique chaque chiffrement même si la clé est la même.

//4
// Ressemblance entre DSA et RSA
//Les deux algorithmes sont utilisés pour la signature numérique et la vérification de l'authenticité des données.
// Diffenrence entre DSA et RSA
//Dans RSA, les clés sont utilisées à la fois pour le chiffrement et la signature,
//tandis que DSA il est seulement possible de signer des données avec la clé privée et de vérifier avec la clé publique.

//5 Chiffrer en AES et dechiffre en DES et vice versa
//entraîne une erreur de déchiffrement car les clés et les vecteurs d'initialisation ne sont pas compatibles.

namespace Labo3
{
    public partial class Form1 : Form
    {
        public enum NomAlgorithme
        {
            Aucun, TripleDES, AES, DSA, RSA
        }

        Object algo { get; set; } = null; // Permet de conserver la clé intacte entre les opérations
        byte[] hash { get; set; } = null; // Utile pour l'algorithme DSA

        public Form1()
        {
            InitializeComponent();

            // Coder ici : remplir une liste déroulante proposant les choix d'algorithmes
        }

        private void algorithme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // On vide le contenu du champ cles
                this.cles.Text = "";
                algo = null;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.GenerateKey();
                tdes.GenerateIV(); // On génère aussi un vecteur d'initialisation
                this.cles.Text = BitConverter.ToString(tdes.Key) + "   (" + tdes.KeySize + " bits)";
                algo = tdes;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.GenerateKey();
                aes.GenerateIV(); // On génère aussi un vecteur d'initialisation
                this.cles.Text = BitConverter.ToString(aes.Key) + "   (" + aes.KeySize + " bits)";
                algo = aes;

            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
                this.cles.Text = dsa.ToXmlString(true) + "    (" + dsa.KeySize + " bits)";
                algo = dsa;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                this.cles.Text = rsa.ToXmlString(true) + "    (" + rsa.KeySize + " bits)";
                algo = rsa;

            }
        }

        private void chiffrer_Click(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = UTF8Encoding.UTF8.GetBytes(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform encrypteur = tdes.CreateEncryptor(tdes.Key, tdes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = (RijndaelManaged)algo;
                ICryptoTransform encrypteur = aes.CreateEncryptor(aes.Key, aes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = (DSACryptoServiceProvider)algo;
                donneesTransformees = dsa.SignData(donneesBrutes);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)algo;
                donneesTransformees = rsa.Encrypt(donneesBrutes, true);
            }

            // On affiche les données chiffrées à l'utilisateur
            this.texteTransforme.Text = Convert.ToBase64String(donneesTransformees, 0, donneesTransformees.Length);
        }

        private void dechiffrer_Click(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = Convert.FromBase64String(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform decrypteur = tdes.CreateDecryptor(tdes.Key, tdes.IV);
                donneesTransformees = decrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = (RijndaelManaged)algo;
                ICryptoTransform decrypteur = aes.CreateDecryptor(aes.Key, aes.IV);
                donneesTransformees = decrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = (DSACryptoServiceProvider)algo;
                if (dsa.VerifyData(donneesTransformees, hash))
                {
                    this.texteTransforme.Text = UTF8Encoding.UTF8.GetString(donneesBrutes);
                    return;
                }
                else
                {
                    this.texteTransforme.Text = "Signature invalide";
                    return;
                }
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)algo;
                this.texteTransforme.Text = UTF8Encoding.UTF8.GetString(rsa.Decrypt(donneesBrutes, true));
                return;
            }

            // On affiche les données déchiffrées à l'utilisateur
            this.texteTransforme.Text = UTF8Encoding.UTF8.GetString(donneesTransformees);
        }
    }
}
