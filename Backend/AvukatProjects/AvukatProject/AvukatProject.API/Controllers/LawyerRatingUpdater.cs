//using AvukatProjectRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Timers;

//namespace AvukatProjectCore.Model
//{
//    public class LawyerRatingUpdater
//    {
//        private readonly AppDbContext _context;
//        private System.Timers.Timer _timer;
//        public LawyerRatingUpdater( AppDbContext context)
//        {
//            _context = context;
//        }
//        public void StartUpdating()
//        {
//            // Zamanlayıcıyı oluşturun ve güncelleme aralığını ayarlayın (örneğin, her gün)
//            _timer = new System.Timers.Timer();
//            _timer.Interval = TimeSpan.FromDays(1).TotalMilliseconds; // 1 gün = 24 saat
//            _timer.Elapsed += TimerElapsed;
//            _timer.Start();
//        }

//        private void TimerElapsed(object sender, ElapsedEventArgs e)
//        {
//            // Güncelleme işlemini burada gerçekleştirin
//            UpdateLawyersRating();
//        }

//        private void UpdateLawyersRating()
//        {
//            try
//            {
//                // Tüm avukatları alın
//                var lawyers = _context.Lawyers.ToList();

//                foreach (var lawyer in lawyers)
//                {
//                    // Avukat için rating ortalamasını ve diğer verileri hesaplayın
//                    var averageRating = CalculateAverageRatingForLawyer(lawyer.Id);
//                    var totalQuestions = GetTotalQuestionsForLawyer(lawyer.Id);

//                    // Avukat tablosunda ilgili sütunları güncelleyin
//                    lawyer.AverageRating = averageRating;
//                    lawyer.TotalQuestions = totalQuestions;
//                }

//                // Değişiklikleri veritabanına kaydedin
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                // Güncelleme işleminde oluşabilecek hataları yönetin
//                Console.WriteLine($"Güncelleme işleminde bir hata oluştu: {ex.Message}");
//            }
//        }
//        private decimal CalculateAverageRatingForLawyer(int lawyerId)
//        {
//            // Belirli bir avukat için rating ortalamasını hesaplayan bir metot
//            var answers = _context.Answers
//                .Where(a => a.LawyersId == lawyerId && a.Rating > 0)
//                .ToList();

//            if (answers.Count > 0)
//            {
//                decimal totalRating = answers.Sum(a => a.Rating);
//                decimal averageRating = totalRating / answers.Count;
//                return averageRating;
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        private int GetTotalQuestionsForLawyer(int lawyerId)
//        {
//            // Belirli bir avukatın toplam soru sayısını alır
//            var totalQuestions = _context.Questions
//                .Count(q => q.LawyerId == lawyerId);

//            return totalQuestions;
//        }
//    }
