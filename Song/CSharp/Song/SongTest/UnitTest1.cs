using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Song;

namespace Song
{
    [TestClass]
    public class SongTest
    {
        [TestMethod]
        public void ExampleCase()
        {
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");

            first.NextSong = second;
            second.NextSong = first;
            Assert.AreEqual(true, first.IsRepeatingPlaylist());
        }
        [TestMethod]
        public void OneSongCase()
        {
            Song first = new Song("Hello");

            Assert.AreEqual(false, first.IsRepeatingPlaylist());
        }
        [TestMethod]
        public void FalseCase()
        {
            Song s1 = new Song("Hello");
            Song s2 = new Song("Trouble");
            Song s3 = new Song("I am yours");
            Song s4 = new Song("Do I wanna know?");
            Song s5 = new Song("What do you mean?");

            s1.NextSong = s2;
            s2.NextSong = s3;
            s3.NextSong = s4;
            s4.NextSong = s5;


            Assert.AreEqual(false, s1.IsRepeatingPlaylist());
        }
        [TestMethod]
        public void TrueCaseLong()
        {
            Song s1 = new Song("Hello");
            Song s2 = new Song("Trouble");
            Song s3 = new Song("I am yours");
            Song s4 = new Song("Do I wanna know?");
            Song s5 = new Song("What do you mean?");
            Song s6 = new Song("I am wry");
            Song s7 = new Song("Creep");
            Song s8 = new Song("When we sleep where do we go?");
            Song s9 = new Song("Ocean Eyes");
            Song s10 = new Song("Frank");
            Song s11 = new Song("Dreaming a little dream of you");
            Song s12 = new Song("Cursed");
            Song s13 = new Song("What is my age again?");


            s1.NextSong = s2;
            s2.NextSong = s3;
            s3.NextSong = s4;
            s4.NextSong = s5;
            s5.NextSong = s6;
            s6.NextSong = s7;
            s7.NextSong = s8;
            s8.NextSong = s9;
            s9.NextSong = s10;
            s10.NextSong = s11;
            s11.NextSong = s12;
            s12.NextSong = s13;
            s13.NextSong = s1;

            Assert.AreEqual(true, s1.IsRepeatingPlaylist());
        }
        [TestMethod]
        public void FalseCaseLong()
        {
            Song s1 = new Song("Hello");
            Song s2 = new Song("Trouble");
            Song s3 = new Song("I am yours");
            Song s4 = new Song("Do I wanna know?");
            Song s5 = new Song("What do you mean?");
            Song s6 = new Song("I am wry");
            Song s7 = new Song("Creep");
            Song s8 = new Song("When we sleep where do we go?");
            Song s9 = new Song("Ocean Eyes");
            Song s10 = new Song("Frank");
            Song s11 = new Song("Dreaming a little dream of you");
            Song s12 = new Song("Cursed");
            Song s13 = new Song("What is my age again?");


            s1.NextSong = s2;
            s2.NextSong = s3;
            s3.NextSong = s4;
            s4.NextSong = s5;
            s5.NextSong = s6;
            s6.NextSong = s7;
            s7.NextSong = s8;
            s8.NextSong = s9;
            s9.NextSong = s10;
            s10.NextSong = s11;
            s11.NextSong = s12;
            s12.NextSong = s13;

            Assert.AreEqual(false, s1.IsRepeatingPlaylist());
        }
        [TestMethod]
        public void PerformanceTest_NaiveImplementation()
        {
            Song s1 = new Song("Hello");
            Song s2 = new Song("Trouble");
            Song s3 = new Song("I am yours");
            Song s4 = new Song("Do I wanna know?");
            Song s5 = new Song("What do you mean?");
            Song s6 = new Song("I am wry");
            Song s7 = new Song("Creep");
            Song s8 = new Song("When we sleep where do we go?");
            Song s9 = new Song("Ocean Eyes");
            Song s10 = new Song("Frank");
            Song s11 = new Song("Dreaming a little dream of you");
            Song s12 = new Song("Cursed");
            Song s13 = new Song("What is my age again?");


            s1.NextSong = s2;
            s2.NextSong = s3;
            s3.NextSong = s4;
            s4.NextSong = s5;
            s5.NextSong = s6;
            s6.NextSong = s7;
            s7.NextSong = s8;
            s8.NextSong = s9;
            s9.NextSong = s10;
            s10.NextSong = s11;
            s11.NextSong = s12;
            s12.NextSong = s13;

            Stopwatch naiveImplementation = new Stopwatch();
            Stopwatch classImplementation = new Stopwatch();

            naiveImplementation.Start();
            NaiveImplementation(s1);
            naiveImplementation.Stop();

            classImplementation.Start();
            s1.IsRepeatingPlaylist();
            classImplementation.Stop();

            Console.WriteLine($"Class Implementation: {classImplementation.Elapsed} VS " +
                $"Naive Implementation: {naiveImplementation.Elapsed}");
            Assert.IsTrue(classImplementation.Elapsed <= naiveImplementation.Elapsed);
        }

        private bool NaiveImplementation(Song song)
        {
            Song currentSong = song;
            while (currentSong.NextSong != null)
            {
                currentSong = currentSong.NextSong;
                if (song.name == currentSong.name)
                    return true;
            }
            return false;
        }

    }
}
