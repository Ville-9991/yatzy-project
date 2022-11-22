namespace yatzy_project;

class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin eventeissä

        private int number_of_sides {get; set;}
        public int value {get; set;}

        public Dice(){
            number_of_sides = 6;
            value = 1;
        }
        public Dice(int sides){
            number_of_sides = sides;
        }

        public int rollDice(){
            Random rng = new Random();
            value = rng.Next(1, this.number_of_sides + 1);

            return value;
        }

        public Bitmap DrawDice(){
            Bitmap dice_image = new Bitmap(filename: $"img\\Dice{value}.png");

            return dice_image;
        }
    }