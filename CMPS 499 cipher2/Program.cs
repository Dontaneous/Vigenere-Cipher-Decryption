//Dante Jones
//September 6, 2017
//I ceritify that this code was done completely by myself.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMPS499_cipher2
{
    public class Program
    {
        // The cipher2 text
        private string cipher2 = "z v w x g y b c y y z s g y m l h v j c s s f l c t q m g p u o r h y y h g d q z s a y f o g w x r n s f j y r h v n l m y w h i h o q p u g h q m g z q f z k h z s x c k h v j b x c k s g t u k f r i v h m c l o z q g l s s q h a g h y c x f w g j k o p t s z w h y f g h g x y x q o x k r s h n r h i f s g s u c s l g a o p c g h c f q z k v j l o h t f j r g o u y x h w r e u b b f p g w g j k e u z f q y o p t t k a m m c g f h y f k b g t k k c b j q n c i y q z v o y q c v o y r n s m l c z t c w y r z h m c e s o w q u t v n r g b r w s t t c w y r z h m c v w g x z x c y j z g b r x m t j v b f k f s i g j o z q r n s w w k u b s d e u r c s r c s o q j q b c b n g f o x g z w q r s y w q n l j i g y p e o g n r j s g y p u m g n r y s z k u k z z x f u k h m c s v c b g z g g z n v c g j b z c p j k a g w h u x w h y c t t f t k j s j t r o c b s m z o a g g z w c s l u h t t p l o a j x k f c u c u d z j y x s s c n r c w y c j h v j p k o f j l u h f n a q g i u m a f g q c k j s l m t b o k g m v h f e g w b x r z v s r y y g o u n k o z b c x s u t l t o y n j r h v j q k j s s p k q c w b j s o q k g y s w c i c f i q z v o y f g j s r m x s h m y t c b j e u c r x m t u h m c j w b t q g i f x u o z z x j u k z d b o s o s b o r c g c r w s a c t c c s c c w z q a x m w r h a g h k s i y w s e m z o i g s u c s l g p s y f k f s y m c o h h f z v s k y r z d w c n w g y m x w q r s y w q n l j i g y p e h v w c k t s j r o b z f z x s o y y x s l y g t q h n m t b s a c x t s q r y c u t m j w t d m a h v n l q o b d m t s k t s r r t j c r p o i j e m c z y x s g f b r m a n q z o y j l z v s y g s s v f q i c a j d u f s a m r i h n m t t i h i i c z q s y w c s i o z z y f k t w a c c v o y c b s f m y v d s s c j h c y f k v o s b y v o p c c v o y c b s f m y v d s s c j h c i c g z g s m u b s b m a z r g p k o y b f g h v f n v s b j b z c w s r k u f n r e w h x q z w z q r n s f j g z o z b y e g k f q l c f u j g m w s e s i g n a p i g y z k q o z q k o a n j r w c s p k o g t l y k v d y r z r n l u g o z p y k w q j j w s";

        public Program()
        {
            string[] letterArray = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            double[] letterFreq = new double[26] { 12.02, 9.10, 8.12, 7.68, 7.31, 6.95, 6.28, 6.02, 5.92, 4.32, 3.98, 2.88, 2.71, 2.61, 2.30, 2.11, 2.09, 2.03, 1.82, 1.49, 1.11, 0.69, 0.17, 0.11, 0.10, 0.07 };
            int[] orderArray = new int[26];
            double[] freqArray = new double[26];
            double[] shiftArray = new double[26]; 

            int count, index, sum;
            double highFreq =0;

            count = index = sum = 0;

            string[] cipher2Array = new string[1043];
            string[] cipher2Answer = new string[1043];

            cipher2Array = cipher2.Split();
            cipher2Answer = cipher2.Split();

            //Use to get the letter freq of each letter
            //I had to change the value of i to 1, 2, 3, 4
            for (int i = 0; i < 1043; i+=5)
            {
               
                    foreach (var element in letterArray)
                    {
                        if(element == cipher2Array[i])
                            orderArray[index] += 1;
                        ++index; 
                    }
               
                index = 0;

            }

            foreach (var element in orderArray)
            {
                sum += element;
            }

            for (int i = 0; i < 26; i++)
            {
                int maxValue = orderArray.Max();
                int maxIndex = orderArray.ToList().IndexOf(maxValue);


                float maxValueFloat = maxValue;
                float freq = maxValueFloat / sum;

                freqArray[maxIndex]= freq;

                //Prints the letter its index and the total number of times it is in the cipher text.
                Console.WriteLine(letterArray[maxIndex] + " is in index: " + maxIndex + " number: " + maxValue + " Cipher freq: " + freq);

                // Clear the number so that I can find the next highest freq.
                orderArray[maxIndex] = 0;

            }

            Console.WriteLine("Sum: "+ sum);


            for (int j = 0; j < 26; j++)
            {
                for (int i = 0; i < 26; i++)
                {
                    if(i+j < 26)
                        highFreq += freqArray[i + j] * letterFreq[i];
                   
                }
                
                shiftArray[j] = highFreq;
                highFreq = 0;
            }

            double maxValue2 = shiftArray.Max();
            int maxIndex2 = shiftArray.ToList().IndexOf(maxValue2);


            Console.WriteLine("Highest Freq is: "+ maxValue2 + " Shifted: " + maxIndex2);
            Console.ReadLine();

        }

        static void Main(string[] args)
        {

            new Program();

        }
    }
}
