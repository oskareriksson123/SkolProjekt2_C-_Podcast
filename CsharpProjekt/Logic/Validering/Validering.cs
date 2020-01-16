﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data;

namespace Logic.Validering
{
   public static class Validering
    {
        public static bool isEmpty(string text)
        {
            bool resultat = false;

            if(text.Equals("") || text.Equals(null))
            {
                resultat = false;
            }
            else
            {
                resultat = true;
            }

            return resultat;
        }

        public static bool isIndexNull(string selectedItem)
        {
            bool resultat = false;
           
            if (selectedItem == null)
            {
                resultat = false;
            }
            else
            {
                resultat = true;
            }

            return resultat;
        }

        public static bool finnsPodcast(string url, Bll bLL)
        {
            bool resultat = false;
            Bll bll = new Bll();
            bll = bLL;
            foreach(var pod in bll.allaPodcasts)
            {
                if (pod.Url.Equals(url))
                {
                    resultat = true;
                }
            }
            return resultat;
        }
        public static bool finnsKategorin(string kategori, Bll bLL)
        {
            bool resultat = false;
            Bll bll = new Bll();
            bll = bLL;
            foreach (var kategorin in bll.allaKategorier)
            {
                if (kategorin.Kategori.Equals(kategori))
                {
                    resultat = true;
                }
            }
            return resultat;
        }

        public static bool CantModifyIngenKategori(int index)
        {
            bool resultat = false;

            if(index == 0)
            {

                resultat = true;
                return resultat;
            }

            return resultat;
            
        }
        public static bool CantRemoveIngenKategori(int index)
        {
            bool resultat = false;
            if (index == 0)
            {
                resultat = true;
                return resultat;

            }
            return resultat;
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidFeedUrl(string url)
        {
            bool isValid = true;
            try
            {

                XmlReader reader = XmlReader.Create(url);
                Rss20FeedFormatter formatter = new Rss20FeedFormatter();
                formatter.ReadFrom(reader);
                reader.Close();
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }


}
