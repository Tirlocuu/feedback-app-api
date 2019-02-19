using FeedbackAppAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppAPI.Logic
{
    public class ReviewsLogic : IReviewslogic
    {
        private string file = @"D:\Projects\FeedbackAppAPI\FeedbackAppAPI\Files\Reviews.in";
        public List<ReviewsModel> GetReviews()
        {
            string line;
            string[] parse;
            List<ReviewsModel> list = new List<ReviewsModel>();
            ReviewsModel model = null;
            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    parse = line.Split(';');
                    model = new ReviewsModel
                    {
                        Id = Convert.ToInt32(parse[0]),
                        Name = parse[1],
                        Email = parse[2],
                        Comment = parse[3],
                        Rate = Convert.ToInt16(parse[4])
                    };

                    list.Add(model);
                }

                reader.Close();
            }
            return list;
        }

        public ReviewsModel GetReview(int id)
        {
            string line;
            string[] parsed;
            ReviewsModel model = new ReviewsModel();
            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (id == Convert.ToInt32(line.Split(';')[0]))  
                    {
                        parsed = line.Split(';');
                        model.Id = Convert.ToInt32(parsed[0]);
                        model.Name = parsed[1];
                        model.Email = parsed[2];
                        model.Comment = parsed[3];
                        model.Rate = Convert.ToInt16(parsed[4]);

                    }
                }
            }
            return model;
        }
        public void AddReview(ReviewsModel model)
        {
            FileInfo f = new FileInfo(file);
            if (f.Length <= 10)
            {
                model.Id = 1;
            }
            else
            {
                model.Id = Convert.ToInt32((File.ReadLines(file).Last()).Split(';')[0]) + 1;
            }

            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(model.ToString());
                writer.Close();
            }
        }


        public void EditReview(ReviewsModel model)
        {
            string[] lines = File.ReadAllLines(file);

            for (var i = 0; i < lines.Length; i++) {
                if (model.Id == Convert.ToInt32(lines[i].Split(';')[0])) {
                    lines[i] = model.ToString();
                    break;
                }
            }

            File.WriteAllLines(file, lines);
        }

        public void DeleteReview(int id)            
        {
            int index = -1;
            var lines = new List<string>(System.IO.File.ReadAllLines(file));
            foreach(var line in lines)
            {
                index++;
                if (id == Convert.ToInt32(line.Split(';')[0])) {
                    break;
                }
            }
            lines.RemoveAt(index);
            File.WriteAllLines(file, lines.ToArray());
        }
    }
}
