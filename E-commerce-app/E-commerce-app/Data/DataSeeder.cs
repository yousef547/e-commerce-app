using E_commerce_app.Entities;
using Hotel_booking.Helpers;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_app.Data
{
    public static class DataSeeder
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(

      new Product
      {
          Name = "Android Small Removable Sticker Sheet",
          Description = "Show your Android pride by placing these 8 fun stickers on your technology products or accessories!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Large Removable Sticker Sheet",
          Description = "Show your quirky side by placing these fun Android stickers on your personal belongings.",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Bot",
          Description = "This Google Bot can hold multiple poses making it a fun toy for all. Fold the Google Bot back up into a perfect cube when you are done playing.",
          Price = 9.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Emoji Sticker Pack",
          Description = "Who doesn't use emojis? Decorate your space with your current mood!",
          Price = 4.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Pack of 9 Decal Set",
          Description = "Can't decide which Waze decal to get? We have made that decision easier for you! Now you can purchase a pack of nine Waze Mood Decals!",
          Price = 16.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Twill Cap",
          Description = "Classic urban styling distinguishes this Google cap. Retains its shape, even when not being worn.",
          Price = 10.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Fold-over Beanie Grey",
          Description = "Keep you ears warm while enjoying a cold winter day with this Google Fold-over Beanie.",
          Price = 9.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Pom Beanie Charcoal",
          Description = "Stay stylish and warm this winter season with this Google Pom Beanie.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Women's Short Sleeve Tee",
          Description = "Made of soft tri-blend jersey fabric, this great t-shirt will help you find your Waze. Made in USA.",
          Price = 18.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Men's Short Sleeve Tee",
          Description = "Made of soft tri-blend jersey fabric, this great t-shirt will help you find your Waze. Made in USA.",
          Price = 18.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Rucksack",
          Description = "Choose to carry your belongings and presentations to your next meeting with the Google Mistral Rucksack!",
          Price = 79.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Rolltop Backpack Blue",
          Description = "This stylish Google rolltop backpack will help keep all of your favorite items organized and together while you're on the move.",
          Price = 149.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Trace Bottle Black",
          Description = "Stay hydrated throughout the day with this Android Trace Bottle. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Trace Mug Black",
          Description = "Start your day off right with that perfect cup of coffee using this Android Trace Mug Black.",
          Price = 9.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Thermal Bottle Blue",
          Description = "Insulated to keep contents hot or cold for hours, this beautiful bottle is a great year-round companion. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Thermal Bottle Green",
          Description = "Insulated to keep contents hot or cold for hours, this beautiful bottle is a great year-round companion. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Thermal Bottle White",
          Description = "Insulated to keep contents hot or cold for hours, this Google bottle is a great year-round companion. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Thermal Bottle Red",
          Description = "Insulated to keep contents hot or cold for hours, this beautiful bottle is a great year-round companion. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Thermal Bottle Yellow",
          Description = "Insulated to keep contents hot or cold for hours, this beautiful bottle is a great year-round companion. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Hub Mug White",
          Description = "Enjoy a cup of coffee or tea with this Google stoneware mug.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Transmission Bottle Black",
          Description = "Keep your favorite drink cold during those long workouts with this YouTube Transmission Bottle. 17 oz.",
          Price = 23.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Snapback Black Cap",
          Description = "Stay shaded on those sunny days wearing this stylish Google snapback hat.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Snapback Navy Cap",
          Description = "Stay shaded on those sunny days wearing this stylish Google snapback hat.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Cappy Bib Blue",
          Description = "Keep your little Googler stain free with this Google Cappy Bib.",
          Price = 13.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Mustachio Bib Blue",
          Description = "Avoid food ending up on your little one with this Google Mustachio Bib.",
          Price = 13.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Cappy Bib White",
          Description = "Keep your little Googler stain free with this Google Cappy Bib.",
          Price = 13.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Mustachio Bib White",
          Description = "Avoid food ending up on your little one with this Google Mustachio Bib.",
          Price = 13.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Standard Bib Red",
          Description = "Catch the Goo Goo with this Google Bib.",
          Price = 13.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Protector Onesie Navy",
          Description = "This Google Protector Onesie moves with your baby with non-binding sleeves for full freedom of movement.",
          Price = 25.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Standard Onesie Grey",
          Description = "This Google onesie moves with your baby with non-binding sleeves for full freedom of movement.",
          Price = 25.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Standard Onesie Green",
          Description = "This Google onesie moves with your baby with non-binding sleeves for full freedom of movement.",
          Price = 25.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Kids Tee Blue",
          Description = "Simple, stylish, and comfy — this Google kids t-shirt is 100% cotton for gentle comfort and ease of care.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Kids Tee Green",
          Description = "Simple, stylish, and comfy — this Google kids t-shirt is 100% cotton for gentle comfort and ease of care.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Kids Tee White",
          Description = "Simple, stylish, and comfy — this Google kids t-shirt is 100% cotton for gentle comfort and ease of care.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Trike Tee Black",
          Description = "This Google t-shirt is perfect for a kid to have fun and play in — 100% cotton comfort, short sleeves, and Google decoration!",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Flower Tee Purple",
          Description = "This Google t-shirt is everything a demanding kid could want — 100% cotton comfort, short sleeves, and Google decoration!",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Protector Tee Navy",
          Description = "This 100% cotton Google Protector is perfect for school, fun or lounging for kids.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Kids Tee White",
          Description = "This 100% cotton YouTube short sleeve t-shirt is perfect for kids to wear to school or while playing.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Kids Tee Black",
          Description = "This 100% cotton YouTube short sleeve t-shirt is perfect for kids to wear to school or while playing.",
          Price = 19.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Kids Onesie White",
          Description = "This 100% cotton YouTube Onesie for your baby will keep them comfortable with non-binding sleeves for full freedom of movement.",
          Price = 25.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Windup Android",
          Description = "Go ahead and wind up in true Android fashion with this fun windup toy!",
          Price = 3.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Sunglasses",
          Description = "Although these are no Google glasses, they will still make your day fun at the beach!",
          Price = 3.5,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Mini Kick Ball",
          Description = "Kick this Google Mini Kick Ball around to take a break from the hustle and bustle. Fun for all ages!",
          Price = 1.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "7 inch Dog Frisbee",
          Description = "Take your furry friend to the park and play the day away with this 7 inch Dog Safe Flyer!",
          Price = 1.5,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Large Trace Journal Black",
          Description = "This Android Large Trace Journal provides an escape and a chance to write down your latest inspirations!",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Small Trace Journal Black",
          Description = "This Android Small Trace Journal provides an escape and a chance to write down your latest inspirations!",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Small Standard Journal Navy",
          Description = "This Google Small Standard Journal is perfect to keep on your desk for those great ideas that pop into your head.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Transmission Journal Black",
          Description = "This YouTube Transmission Journal is a convenient tool to collect your thoughts and doodles throughout the day.",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Laptop and Cell Phone Stickers",
          Description = "Show your Google support by posting these stickers on your belongings!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Maze Pen",
          Description = "Attending a meeting will never be the same! This fun-filled maze pen features two small metal balls that move through the maze.",
          Price = 0.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tri Pen Black",
          Description = "Switch between blue ink, black ink, pencil or even write on your tablet using the stylus with this 5-in-1 Tri Pen.",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tri Pen Silver",
          Description = "You multitask like a boss. Now your writing instrument can keep up. This 5-in-1 Tri Pen is a great multi functional pen.",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Stylus Pen w/ LED Light",
          Description = "Get yourself a great multitasking tool! Write a note, sign a tablet, and shine a light with this Google Stylus Pen w/LED Light!",
          Price = 5.5,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Large Standard Journal Grey",
          Description = "Use all 192 pages to store anything from meeting notes to that next big idea in this Google hard cover notebook.",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Large Standard Journal Navy",
          Description = "Use all 192 pages to store anything from meeting notes to that next big idea in this Google hard cover notebook.",
          Price = 15.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Metallic Notebook Set",
          Description = "A stunning notebook set that will inspire all writers!",
          Price = 5.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Baby on Board Window Decal",
          Description = "Get on board with the Waze wave and let everyone know you're carrying precious cargo with this new Waze inchBaby on Board inch decal.",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Mood Happy Window Decal",
          Description = "If you're happy and you know it, show it off with this Waze happy mood window decal.",
          Price = 1.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Mood Original Window Decal",
          Description = "You're an original. Let everyone know with this original Waze mood window decal.",
          Price = 1.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Mood Ninja Window Decal",
          Description = "You're a master of stealth. So let everyone know! Get this Waze ninja mood window decal and advertise your commitment to the secret ninja ways!",
          Price = 1.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Women's Typography Short Sleeve Tee",
          Description = "Made of soft tri-blend jersey fabric, this great t-shirt will help you find your Waze. Made in USA.",
          Price = 18.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Waze Men's Typography Short Sleeve Tee",
          Description = "Made of soft tri-blend jersey fabric, this great t-shirt will help you find your Waze. Made in USA.",
          Price = 18.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tee White",
          Description = "100% cotton jersey fabric sets this Google t-shirt above the crowd. Features the Google logo across the chest. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tee Red",
          Description = "100% cotton jersey fabric sets this Google t-shirt above the crowd. Features the Google logo across the chest. Unisex Sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tee Yellow",
          Description = "100% cotton jersey fabric sets this Google t-shirt above the crowd. Features the Google logo across the chest. Unisex Sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tee Green",
          Description = "100% cotton jersey fabric sets this Google t-shirt above the crowd. Features the google logo across the chest. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Tee Blue",
          Description = "100% cotton jersey fabric sets this Google t-shirt above the crowd. Features the google logo across the chest. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Bike Tee Navy",
          Description = "Go for a ride around campus or town with this comfortable Google Bike Tee. Unisex Sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Braille Tee Black",
          Description = "Made of soft tri-blend material, this Google Braille Tee is perfect for all of those sunny days. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Women's Tee Grey",
          Description = "Stay comfortable and relaxed while coding in this Google Women's Tee made of soft tri-blend material.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Matrix Tee White",
          Description = "The unique design and soft tri-blend material make for a perfect combination for this Android Matrix Tee. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Tee Black",
          Description = "Keep it simple with the new logo wearing this YouTube tee. Unisex sizing.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Light Pen Blue",
          Description = "Get yourself a great multitasking tool! Write a note, sign a tablet, and light up with this Google Light Pen!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Light Pen Green",
          Description = "Get yourself a great multitasking tool! Write a note, sign a tablet, and light up with this Google Light Pen!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Light Pen Red",
          Description = "Get yourself a great multitasking tool! Write a note, sign a tablet, and light up with this Google Light Pen!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Light Pen Yellow",
          Description = "Get yourself a great multitasking tool! Write a note, sign a tablet, and light up with this Google Light Pen!",
          Price = 2.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android 16 oz Tumbler Black",
          Description = "Insulated to keep contents hot or cold for hours, take that perfect cup of coffee with you on the go whether you like hot or iced coffee.",
          Price = 21.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android 25 oz Gear Cap Bottle White",
          Description = "Take your favorite hot or cold drink anywhere with this Android 25oz Gear Cap Bottle. The carrying handle lid makes it convenient to take with you to your next meeting or workout.",
          Price = 26.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Android Twill Cap Black",
          Description = "Show your Android pride by wearing this Android Twill Cap.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google 16 oz Tumbler Blue",
          Description = "A geometric inner liner gives this Google 16oz Tumbler a unique look to help you stand out in a crowd of bottles and tumbler.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "Google Twill Sandwich Cap Navy",
          Description = "This Google Twill Sandwich Cap will not only keep the sun out of your eyes but will also keep you looking stylish.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube 25 oz Gear Cap Bottle Black",
          Description = "Take your favorite hot or cold drink anywhere with this YouTube 25oz Gear Cap Bottle. The carrying handle lid makes it convenient to take with you to your next meeting or workout.",
          Price = 26.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Twill Sandwich Cap Black",
          Description = "This YouTube Twill Sandwich Cap will not only keep the sun out of your eyes but will also keep you looking stylish.",
          Price = 12.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Icon Pullover Black",
          Description = "This YouTube pullover hoodie will keep you warm while looking stylish with the tone on tone logo.",
          Price = 59.99,
          StockQuantity = GenerateRandomNumber(0,50)
      },
      new Product
      {
          Name = "YouTube Wordmark Crew Grey",
          Description = "Kick back and relax in this comfortable YouTube sweatshirt. Unisex sizing.",
          Price = 51.99,
          StockQuantity = GenerateRandomNumber(0,50)
      }
                    );
            }
            context.SaveChanges();
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1); // max is exclusive, so add 1
        }

   
    }
}
