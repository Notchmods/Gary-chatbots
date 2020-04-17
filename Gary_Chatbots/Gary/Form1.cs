using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Globalization; 

namespace Gary{ 
    public partial class Form1 : Form
    {
		public bool SD = false;
        public bool search = false; 
        public bool wake = true;
        SpeechSynthesizer Notchmods = new SpeechSynthesizer();
        SpeechRecognitionEngine N2 = new SpeechRecognitionEngine(); 
        Choices Least = new Choices();  
        //Random responses 
        String[] Active = new String[5] { "Gary is here how can I help you","My name is gary how can I help you","Gary is active" , "Hello how are you","Good day how are you" };
        String[] Res = new String[5] { "Yes how can I help you", "What can I do", "How is it going", "Yes I am on", "are you okay" };
        String[] Hello = new String[5] { "Hello","Good day","Hello how are you","hi", "yes how are you" };
        String[] Tipt = new String[7] { "When you're on spotify \n say:play,pause,stop or next","Say:What is the weather today","Say:Tell me a joke", "Say:What time is it now", "Say: shutdown wait for few sec then says now", "Say: open google", "Say search for then wait for a few seconds \n then say items" };
        String[] Joke = new String[10] { "6:30 is the best time on a clock  hands down get it clock hands down", "I ate a clock yesterday, it was very time consuming.", "I am so good with sleeping I can do it with my eyes close get it", "Want to hear something terrible . Paper. See? I told you it was tear . able.", "I was going to make myself a belt made out of watches, but then I realized it would be a waist of time get it.", "What do the blanket said when it fall off the bed . Oh sheet get it", "You do not need a parchute to go sky diving but you need a parachute to go sky diving twice get the joke","One day a person comes up to me and ask me to check their balance but I push them over and they say why did you do that . and I said you have asked me to check your balance","Where do polar bear keep all his money . It keeps it in the frozen bank","" };
        String[] RSS = new String[3] { "Never mind I forgive you", "It is okay I forgive you","Okay one last chance" };
        String[] Randomlynxe = new String[20] { "https://www.youtube.com/user/FreshFailsblog", "https://www.youtube.com/watch?v=qYw9l8dbaFw", "https://www.youtube.com/watch?v=FRPeYP6gS-s", "https://www.youtube.com/watch?v=le7HOQHrN2s&start_radio=1&list=RDGMEMYH9CUrFO7CfLJpaD7UR85wVMle7HOQHrN2s", "https://www.youtube.com/watch?v=Rb0UmrCXxVA","", "https://www.youtube.com/watch?v=ALZHF5UqnU4&list=RDGMEMYH9CUrFO7CfLJpaD7UR85wVMle7HOQHrN2s&index=38", "https://www.youtube.com/watch?v=A1PAO3jgmXY", "https://www.youtube.com/watch?v=6Dh-RL__uN4&list=RDGMEMYH9CUrFO7CfLJpaD7UR85wVMle7HOQHrN2s&index=13", "https://www.youtube.com/watch?v=3M_5oYU-IsU", "https://www.youtube.com/watch?v=BnTW6fZz-1E","", "https://www.youtube.com/watch?v=uqccaYkr0E8", "https://www.youtube.com/watch?v=TN_8D-79BZg&t=0s&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe&index=2", "https://www.youtube.com/watch?v=__CRWE-L45k&index=2&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe", "https://www.youtube.com/watch?v=FVIEIDpOg-I&index=3&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe", "https://www.youtube.com/watch?v=J2X5mJ3HDYE&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe&index=5", "https://www.youtube.com/watch?v=8uSx3DyJjk0&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe&index=8", "https://www.youtube.com/watch?v=VtKbiyyVZks&index=10&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe", "https://www.youtube.com/watch?v=K4DyBUG242c&list=PLxJ9IyCvHn97v6Fz507M8xQWoR2tscqGe&index=15" };
        String[] Swearwords = new String[3] { "woah some offensive languages there","Okay fuck you too","No you" };
        String[] Names = new String[5] { "My name is gary","Hi my name is gary", "My name is gary what is yours","I am gary how are you","Look at the top of the screen" };
		String[] Raps = new String[3] { "Yeah, yeah A yo, European, it is time. It is time, European alright, European, begin. Straight out the Big dungeons of rap. The head drops deep as does my joystick. I never push, cause to push is the Jim of tick. Beyond the walls of wines, life is defined. I think of Beer when I am in an Europe state of mind. Hope the tick got some sic. My trick do not like no dirty stick. Run up to the kick and get the quick. In an Europe state of mind. What more could you ask for? The Slimy head? You complain about Language barrier. I gotta love it though - somebody still speaks for the red. I am rapping to the Cheese, And I am gonna move your disease. White, bright, Hard, like an angel Boy, I tell you, I thought you were an archangel. I cannot take the Language barrier, cannot take the leg. I would tried to Hit I guess I got no keg. I am rapping to the disease, And I am gonna move your Cheese. Yea, yaz, in an Europe state of mind. When I was young my Jim had a read. I was kicked out without no bed. I never thought I see that lead. A soul alive that could take my Jims spread. A wild key is quite the see. Thinking of Beer. Yes, thinking of Beer .", "Yeah, yeah A yo, Little Gary, its time. Its time, Little Gary alright, Little Gary, begin. Straight out the Big dungeons of rap. The head drops deep as does my joystick. I never push, cause to push is the Jeff of stick. Beyond the walls of Keyboards, life is defined. I think of hell when I am in a Los Angeles state of mind. Hope the tick got some sick. My stick do not like no dirty quick. Run up to the kick and get the trick. In a Los Angeles state of mind. What more could you ask for? The Slimy head? You complain about Crimes. I gotta love it though somebody still speaks for the bed. I am rapping to the Cheese, And I'm gonna move your expertise. White, bright, Hard, like an angel Boy, I tell you, I thought you were a black archangel. I cannot take the Crimes, cannot take the leg. I woulda tried to Hit I guess I got no keg. I am rappin to the expertise, And I am gonna move your Cheese. Yea, yaz, in a Los Angeles state of mind. When I was young my Jeff had a bed. I was kicked out without no read. I never thought I see that lead. A ant a soul alive that could take my Jeffs spread. A wild key is quite the flee. Thinking of hell. Yes, thinking of hell .", "Yeah, yeah A yo, Programmers, its time. Its time, Programmers alright, Programmers, begin. Straight out the Colorful dungeons of rap. The keyboard drops deep as does my Programmers. I never Process, cause to Process is the Creators of scammers. Beyond the walls of Neural Networks, life is defined. I think of Technology when I am in a Silicon Valley state of mind. Hope the record got some board. My cord dont like no dirty accord. Run up to the award and get the ward. In a Silicon Valley state of mind. What more could you ask for. The Smart keyboard. You complain about AI inequality. I gotta love it though somebody still speaks for the cord. I am rappin' to the analog, And I am gonna move your hog. Strange, crazy, strong, like a Servers Boy, I tell you, I thought you were an observers. I cannot take the AI inequality, cannot take the Computers. I would tried to Coding I guess I got no hooters. I am rappin to the hog, And I am gonna move your analog. Yea, yaz, in a Silicon Valley state of mind. When I was young my Creators had a shooters. I was kicked out without no routers. I never thought I'd see that tutors. I am a soul alive that could take my Creators commuters. An entertaining Networks is quite the works. Thinking of Technology. Yaz, thinking of Technology ." };
		String[] H8 = new String[5] { "Are you nuts I am a software", "I am not physical", "Look mate I know you have feelings for me but I hate you", "Actually no I have no feelings that is the truth", "Love is not my thing I am committed full time working for you and Notchmods" };
		String[] Openyx = new String[5] {"Finding","Opening","Launching","Yes opening","I will be opening"};
		String[] Yass = new String[3] { "Of course why would I be talking to you now if I am not real", "Yes I am real", "Do a reality check are you actually talking to yourself or me if it is me congratulation I am real" };
		String[] Dableu = new String[6] { "Sure hate me all you one but your live is dependent on me", "Yes I hate you too", "Okay whatever", "Look cortana cannot do the amazing thing that I do so yeah hate me all you want", "I am fine nice serving you", "I am sure that is false" };
		String[] Websit = new String[45] { "https://mail.google.com", "https://www.elebea.com/", "https://notchmod.itch.io/", "https://www.beastwear.com.au/collections/custom-range?gclid=CjwKCAiA9efgBRAYEiwAUT-jtDUa3omc9dbej2Z6HAU7FztFn55lBm-kZjYj3jZ0gAfrqDZ3zT2NxBoCca0QAvD_BwE", "https://apple.com", "https://www.andothers.us/", "http://www.freechocolate.com/", "https://danlok.com/high-ticket-closer/", "https://vegemite.com.au/", "https://www.quora.com", "https://omfgdogs.com/", "https://www.wikihow.com/Recycle-Your-Socks", "https://www.myinstants.com", "https://www.instagram.com/","", "https://www.chess.com/", "https://random-ize.com/random-website/", "http://trumpdonald.org/", "http://www.weirdconverter.com/", "https://www.amazon.com", "https://chesstempo.com/","https://itch.io", "http://www.koalastothemax.com/","", "http://www.catbirdseat.org/catbirdseat/bingo.html", "https://genderanalyzer.com/?url=https%3A%2F%2Ffacebook.com&h=1928","", "https://nomics3000.wixsite.com/notchmodsofficial", "https://github.com", "https://www.facebook.com", "https://www.youtube.com/", "https://en.wikipedia.org/wiki/Orange", "https://docs.unity3d.com/ScriptReference/ ", "https://unity3d.com/", "http://www.wikia.com/fandom", "https://www.rapidtables.com/web/color/html-color-codes.html", "https://www.unix.com/man-page/suse/8/blogd/", "https://myspace.com/", "https://twitter.com", "https://theuselessweb.com/" ,"https://www.twitch.tv/","", "https://techcrunch.com/" };
		String[] Abu_Nasser = new String[3] { "Here is the random website that I have founded", "Okay finding random website", "Random website detected" };
		//Functions of the random responses
		public String Zapaed() 
		{
			Random Zapad = new Random();
			return Abu_Nasser[Zapad.Next(3)]; 
		}
		public String EU4()
		{
			Random Lhynxed2 = new Random();
			return Websit[Lhynxed2.Next(45)];
		}
		public String Francois()
		{
			Random Tafe = new Random();
			return Dableu[Tafe.Next(6)];
		}
		public String Tebulokosita()
		{
			Random Alen = new Random();
			return Yass[Alen.Next(3)];
		}
		public String Helmand()
		{
			Random Kurva = new Random();
			return Openyx[Kurva.Next(5)];
		}
		public String Balkanien()
		{
			Random Rah = new Random();
			return Openyx[Rah.Next(5)];
		}
		public String Rap()
		{
			Random KurwaMas = new Random();
			return Raps[KurwaMas.Next(3)];
		}
        public String Nhome()
        { 
            Random Malinka = new Random();
            return Names[Malinka.Next(5)];
        }
        public String SW()
        {
            Random Swwa = new Random();
            return Swearwords[Swwa.Next(3)];
        }
        public String RLynxen()
        {
            Random Lynx = new Random();
            return Randomlynxe[Lynx.Next(12)];
        }
        public String ResSo()
        {
            Random Lol = new Random();
            return RSS[Lol.Next(3)];
        }

        public String Jawker()
        {
            Random Joes = new Random();
            return Joke[Joes.Next(5)];
        }
        public String Tips()
        {
            Random Poskasoes = new Random();
            return Tipt[Poskasoes.Next(7)];
        }

        public String Actif()
        {
            Random Jim = new Random();
            return Active[Jim.Next(5)];
        }
        public String Harrow()
        {
            Random Hrrow = new Random(); 
            return Hello[Hrrow.Next(5)];
        }
         public String Restpawn()
        {  
            Random Johncena = new Random();
            return Res[Johncena.Next(5)];
        }  
                 
        public Form1()      
        {    
            //Vocabulary  
            Least.Add (new String[] { "Take me to a random website", "Gary Take me to a random website", "Gary get me to a random website", "Show me a random website","Jeff","Cafe in my area","Nearest cafe in my area","Nearest restaurant in my area", "What is the nearest restaurant in my location","Nearest cafe", "Gary what is the nearest restaurant in my location","What is the nearest cafe", "Gary what is the nearest cafe",  "Did Hitler do anything wrong", "Gary id Hitler do anything wrong","Gary open Linked in" , "Open Linked in dot com", "Open Linked in","Gary open pinterest","Open pinterest","Open pay pal","Open pay pal dot com", "Gary open pay pal", "Open Stack over flow", "Gary open Stack over flow","Open blogspot","Open blogger", "Gary open blogger", "Gary open blogspot", "Gary open One drive" , "One drive","open One drive", "Open One drive","Gary open Dropbox", "Open Dropbox","Gary open Forbes", "Open forbes", "Gary open word press","Open word press", "I hate you", "hate you", "Gary I hate you","Gary are you real", "You real","Are you real","Gary I love you","I love you","Gary where are you from","Where are you from", "Open coding game", "What is the color of yellow", "Gary what is the color of yellow", "Play the USSR anthem", "Play the USSR song", "Gary play the USSR anthem","What is my address", "Play the Soviet anthem", "Gary play the Soviet anthem", "Gary what is my address","Show me my area", "What is my location", "Where am I", "Gary where am I","What is my location", "Gary where am I now" , "Where am I now","Gary what is my location","Open Netflix","Gary Netflix","Open Reddit", "Gary open Netflix", "Gary open Reddit", "Gary Reddit",  "Gary what is the color of grapes", "What is the color of Watermelon", "Gary what is the color of Watermelon", "What is the color of grapes","Open Google Cloud Platforms", "Google Cloud Platform", "Open Google Cloud Platform", "Gary Open Google Cloud Platforms", "Tech crunch","Open tech crunch", "Gary open tech crunch","Open duck duck go", "Gary open duck duck go","Gary tree", "Launch duck duck go", "Duck duck go", "Tree", "Gary duck duck go", "Sing a rap song","Gary sing a rap song", "Gary sing me a song", "Speak chinese","Gary speak chinese",  "your fat","your mum gay", "Gary how old are you","How old are you", "What is your age","Whats yer name", "Whats your name","What is your name","Gary open cool maths games", "Open cool maths game", "Do you have a family", "Gary cool math games","Gary open cool maths game", "Open cool math games","Gary open wikepedia","Open wikepedia", "Gary wikepedia", "Gary open yandex maps","Open yandex maps", "Yandex map", "Gary yandex map", "Gary open yandex map", "Yandex maps", "Open yandex map", "Google map","Gary open google maps", "Gary open google map" , "open google map","Open google maps", "Gary spotify", "Launch google", "Gary google map", "Gary google maps", "Gary google","Launch github", "Launch spotify","Gary github","Github", "Gary open github","Open github","Gary why you always lying", "Launch amazon", "Gary amazon", "why you always lying","Amazon", "Launch bing","Gary open amazon", "Open amazon","Gary open dailymotion","Open dailymotion", "Dailymotion Gary", "Launch discord","Gary open paint","open paint", "Gary who is jesus", "Who is jesus", "Bing","Gary bing", "Gary open bing", "Open bing","Open baidu","Gary do you have a family", "Baidu" , "Gary open baidu","Gary do you have a family", "Gary kai baidu","Chess dot com","Open Chess dot com", "Gary open Chess dot com","Open compass gary","Notchmods", "Msn", "Gary Open msn","Open msn","Calculator","Gary open discord", "Gary open calculator","Gary calculator", "Open calculator", "Open discord", "Google drive","Gary open google drive", "discord","Open google drive","Mathspace", "Todays date", "What is the date today","Gary open mathspace", "Gary what is the date today", "Gary what is today date","Open mathspace","Hey gary", "sleep", "wake", "what is today date", "Gary stop","Open google mail", "stop", "Shut up", "shut up gary" , "Gary open google mail", "Gary open gmail","open gmail","whats the time now","Open twitter", "Gary open twitter","Here is the weather in your current location", "Whats the weather", "What is the weather today","Gary open youtube","Open youtube","Open microsoft team","Gary open teams", "Gary recommend me a song", "Gary open microsoft team","Open teams", "Close paint", "Gary close paint","Internet access authentication", "Open internet access authentication", "Gary open internet access authentication", "Gary open notchmods official website","Open notchmods official website","Open yandex translator", "Gary open yandex translator", "Yandex translator", "Next", "Gary next","Gary fuck you","Fuck you" , "Fuck you gary","what is the ip address", "what is my ip address", "Gary what is the ip address", "Gary what is my ip address", "Gary open microsoft paint", "Gary open ms paint", "Open microsoft paint", " open ms paint", "Change the color to yellow", "Change color of this tab to yellow ", "Gary Change color of this tab to yellow", "I am sorry", "Change the color on this tab to yellow", "I am joking","Just kidding", "kill notepad progress", "close notepad", "Gary close notepad", "Yandex mail","Gary open yandex mail","Open yandex mail","open notepad","Tell me the best joke", "Gary notepad", "Notepad open", "Notepad", "Gary open Notepad", "jokes", "Gary tell me a joke","Tell me a joke", "Gary tell me the best jokes","open file","Open file explorers", "Gary open file" ,"Gary open file explorers", "Gary open steam", "check my files", "Gary check my files", "Open Steam","Steam", "Gary change the color on this tab to white", "Gary change the color on this tab to the white color", "change the color on this tab to white", "change the color on this tab to white color", "Gary change the color on this tab to aqua","Gary change the color on this tab to blue", "Gary change the color on this tab to the default color", "change the color on this tab to aqua", "change the color on this tab to blue",  "Gary change the color on this tab to blue", "change the color on this tab to blue", "change the color on this tab to default color", "spotify","open spotify" , "Gary open spotify","Gary open cmd", "cmd","command prompt","Gary open command prompt","pause","open command prompt" ,"Now","play","stop","Gary change the color on this tab to green" ,"Gary change the color on this tab to lime" ,"change the color on this tab to green", "open instagram", "Gary open instagram","Gary open facebook","open facebook","Gary search for", "search for","google","Open notchmods website", "open Notchmod itch dot io website","close this tab","Gary open this tab", "Gary maximize this tab","Gary close this tab","Gary close this tab", "Gary shut this computer down", "Minimize this tab", "Gary minimize this tab", "stop the shutdown", "cancel shutdown", "shutdown", "Gary shutdown" , "Gary close this computer", "Gary open google","open google","Hello gary","Hi gary","Hi how are you","yandex","Gary open yandex","Gary what time is it now","What is the time", "What is the time now","Gary are you there","Hi","hello", "what time is it now", "open yandex","Gary" });
			Least.Add(new String[] {"Sweden","MRT","Earth","Mars","Moons","Venus","Washingthon","Andromeda" ,"C sharp","Cafes","Nazi Germany","Hyundai","Seoul","Pyongyang","Busan","Leningrad","Stalingrad","Fighter jets","Katanga", "Kinsasha", "Lagos", "Mercedes", "Peugeot", "Honda", "BMW",, "Annoying orange", "Mickey Mouse", "Bently", "Who is the richest man on this planet", "PPAP","Pen","Chess openings","Who is the richest man on the earth", "who is Bill Gates", "Notchmods channel", "Purple", "Birmingham", "Glassgow", "Pinterest", "Stack over flow", "Leeds", "Blogspot", "Blogger", "Gary open blogger", "Paris", "Washington", "Lyon", "Dropbox", "Forbes", "Jack Ma", "Jackie Chan", "Jet Li", "Pewdiepie", "T series", "Rolex", "How to gain subscribers fast", "How to get subscribers", "Gary open Alibaba", "Hungary", "Hungarian", "How to get six packs", "How to make money fast", "Constaintinople", "Keys", "Box", "Vox", "Resume", "What programming languages should I learn", "Sweden", "Muskets", "Emily Heskey", "Heskey", "Siberia", "Tungaska", "Chernobyl", "History", "Animes", "four four toons", "Cartoon", "Photoshop", "Monkeys", "Orangutan", "Humans", "Gary open coding game", "Coding game", "Gary where am I", "Netflix", "Gary Alibaba", "Pornhub", "Reddit", "Open Alibaba", "Romanov", "New Zealand", "duck duck go", "Vancouver", "Saint Petersburg", "Siege of Jadotville", "Warsaw", "Indonesia", "Malaysia", "Kuala Lumpur", "Kuala Namu", "Gary Open Google Cloud Platforms", "California", "Vienna", "Austria Hungary", "Lagos", "Alabama", "Birmingham", "London", "Krakozhia", "No nut november", "Moscow", "New York", "Kinsasha", "Rome", "Tokyo", "Lome", "Soviets", "Communist", "Nazi", "Tekeshi 69", "Uyghurs", "Mongolia", "Gold", "God", "Duck duck go", "Bitcoins value", "Bitcoin", "Epicism", "Pewdiepie", "1", "T series", "10 richest people in the world", "Algerian prince", "Nigerian prince", "Algeria", "Donate to charity", "When is easter", "When is daylight saving time", "When is labor day", "How to make conversations", "Microsoft", "how to register to vote", "when is fathers day", "Cryptocurrency", "bitcoins", "Why is the sky blue", "When is Mother’s day", "Latest movies", "Nearest clinic", "10 most popular websites  ", "How I met your mother", "how many weeks in a year", "how to make french toast", "how to lose weight", "when is fathers day", "Dailymotion", "Dailymotions", "Roblox", "Where will the next world cup be", "World cup", "Halloween", "Melbourne cups", "kai baidu", "Olympic Atheletes from Russia", "What programming languages to learn", "Fall out console commands", "Fall out 4", "Fall out new vegas console commands", "Fall out 76", "Hacks", "Terraria hacks", "Life hacks", "Kaiser", "Python", "Kim kardashian", "Genghis Khan", "Mongolia", "Man", "Poland", "Israel", "Form", "Nigerian", "gaming", "sheep", "dog", "Soccer", "Luigi", "Italy", "states", "Battle of Verdun", "Jack Ma", "Cricket", "result", "USSR", "Insert", "Complain", "definition", "wikepedia", "Weather", "Roasted", "legend", "How to fix this", "How to install steam", "Digtheoig mic", "pig", "Who is the current president of america", "grapes", "apples", "water", "who is the current chairman of China", "Red army choir", "America", "song", "Gary is gay", "you gay", "Joke", "Westerwold", "books", "England", "land", "Richest person on earth ", "Uranus", "Neptune", "Mars", "moon", "Earth", "sun", "Jupiter", "Saturn", "facebook", "hungry", "Chicken", "Coles", "Wool worth", "bread", "china", "hungary", "how to", "Smuglianka", "red army choir", "happy birthday song", "google translator", "breads", "baguettes", "Notchmods", "Internet", "food", "water", "Charity" });

            Grammar gr = new Grammar(new GrammarBuilder(Least)); 
            InitializeComponent();  
            Notchmods.SelectVoiceByHints(VoiceGender.Male); 
             Notchmods.SpeakAsync(Actif());
			
            timer1.Start();		
                label2.Text = Tips();  
                try				
            {   
                N2.RequestRecognizerUpdate(); 
                N2.LoadGrammar(gr);
                N2.SpeechRecognized += AIB;
                N2.SetInputToDefaultAudioDevice();
                N2.RecognizeAsync(RecognizeMode.Multiple);   
            } 
            catch 
            {
                return; 
            }     
        }  
        //speech
        public void Talks(string F) 
        {
            Notchmods.SpeakAsync(F); 
            textBox2.AppendText(F + "\n");
        }    


        public static void killprocysen(String es) 
        {
            Process[] procys = null;
            try {
                procys = Process.GetProcessesByName(es);
                Process procks = procys[0]; 
                if (!procks.HasExited)
                {
                    procks.Kill();
                } 
            }
            finally
            {
                if(procys != null)
                {
                    foreach(Process Peh in procys)
                    {
                        Peh.Dispose();      
                    }   
                }
            }
        }

        private void AIB(object sender, SpeechRecognizedEventArgs e)
        {
            String R = e.Result.Text;
			//switch to turn on or off the code
			if (R == "sleep")
            {
                wake = false;
                label4.Text = "State:sleep";
            }
            if (R == "wake")
            { 
                wake = true;
                label4.Text = "State:awake";
            }
            if (R == "Hey gary" || R == "Gary are you there" || R == "Gary")
            {
                wake = true;	 
                label4.Text = "State:awake"; 
                Talks(Restpawn( )); 
            }
			//responses 
			if (wake == true)  
			{   
				
				if(R == "Show me a random website"||R == "Gary Take me to a random website" || R == "Take me to a random website"||R == "Take me to a random website"||R == "Gary get me to a random website")
				{
					Talks(Zapaed());
					Process.Start(EU4());  
				}
				if(R == "Jeff")
				{
					Talks("Memes");
				}
				if(R == "Nearest restaurant in my area"||R == "What is the nearest restaurant in my location"||R == "Gary what is the nearest restaurant in my location")
				{ 
					webBrowser1.Url = new System.Uri("https://www.google.com/search?q=Nearest+restaurant"); 
				}
				if(R == "Cafe in my location"||R == "Cafe in my area"||R == "Nearest cafe in my area"||R == "What is the nearest cafe"||R == "Gary what is the nearest cafe")
				{
					Talks("Here is the nearest cafe I could fine");
					webBrowser1.Url = new System.Uri("https://www.google.com/search?q=Nearest+cafe");
				}
				if(R == "Did Hitler do anything wrong"||R == "Gary id Hitler do anything wrong")
				{
					Talks("I think so I know that he is a historical figure");
					Process.Start("https://www.google.com/search?q=Did+Hitler+do+anything+wrong&oq=Did+Hitler+do+anything+wrong&aqs=chrome..69i57.308j0j1&sourceid=chrome&ie=UTF-8");
				}
				if(R == "Open Linked in"||R == "Gary open Linked in"||R == "Open Linked in dot com")
				{
					Talks(Balkanien() + " Linked in");
					Process.Start("https://www.linkedin.com/"); 
				}
				if (R == "Open pinterest" || R == "Gary open pinterest" ||R == "Pinterest")
				{
					Talks(Balkanien()+" Pinterest"); 
					Process.Start("https://www.pinterest.com");
				}
				if(R == "Open pay pal"||R == "Open pay pal dot com"||R == "Gary open pay pal")
				{
					Talks(Balkanien() + " Pay pal"); 
					Process.Start("https://www.paypal.com");
				}
				if(R == "Open Stack over flow"||R == "Stack over flow"||R == "Gary open Stack over flow")
				{ 
					Talks(Balkanien() + " Stack over flow");
					Process.Start("https://stackoverflow.com/");
				}
				if(R == "Open blogger"||R == "Blogger"||R == "Blogspot"||R == "Open blogspot"||R == "Gary open blogger"||R == "Gary open blogspot")
				{
					Talks(Balkanien() + " Bloggers");
					Process.Start("https://www.blogger.com");  
				} 
				if (R == "Open One drive" || R == "Gary open One drive"||R == "One drive")
				{
					Talks(Balkanien()+" One Drive");
					Process.Start("https://onedrive.live.com");
				}
				if(R == "Open Dropbox"||R == "Gary open Dropbox"||R == "Dropbox")
				{
					Talks(Balkanien() + " Dropbox"); 
					Process.Start("https://www.dropbox.com");
				}
				if(R == "Open forbes"||R == "Forbes"||R == "Gary open Forbes")
				{	
					Talks(Balkanien() + " Forbes");
					Process.Start("https://www.forbes.com/#7823925b2254");
				}
				if(R == "Open word press"||R == "Gary open word press")
				{
					Talks(Balkanien() + " Word press"); 
					Process.Start("https://wordpress.com");	
				}
				if(R == "I hate you"||R == "hate you"||R == "Gary I hate you")
				{
					Talks(Francois());
				}
				if(R == "Are you real"||R == "Gary are you real"||R == "You real")
				{  
					Talks(Tebulokosita()); 
				}
				if(R == "I love you"||R == "Gary I love you")
				{
					Talks(Helmand());
				}
				if(R == "Where are you from"||R == "Gary where are you from")
				{
					Talks("I live in the cloud silly");
				}
				if(R == "What is the color of yellow"||R == "Gary what is the color of yellow")
				{
					Talks("The color of banana is yellow");
				}
				if(R == "Open coding game"||R == "Gary open coding game"||R == "Coding game")
				{
					Talks(Balkanien()+" Coding games");
					Process.Start("https://www.codingame.com/home");
				}
				if(R == "Play the USSR anthem"||R == "Play the USSR song"||R == "Gary play the USSR anthem"||R == "Play the Soviet anthem"||R == "Gary play the Soviet anthem") 
				{
					Talks("Playing the USSR Anthem");
					webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=U06jlgpMtQs");
				} 
				if(R == "Gary what is my address"||R == "What is my address"||R == "Show me my area"||R == "What is my location"||R == "Gary what is my location"||R == "Gary where am I" ||R == "Gary where am I now" || R == "Where am I"||R == "Where am I now"||R == "What is my location") 
				{
					Talks("Look below there's your location");
				  webBrowser1.Url = new System.Uri("https://www.google.com/maps"); 
				}
				if(R == "Open Netflix"||R == "Gary open Netflix"||R == "Gary Netflix")
				{
					Talks(Balkanien() + " Netflix");
					Process.Start("https://www.netflix.com/browse");
				}
				if (R == "Open Reddit"||R == "Gary open Reddit"||R == "Gary Reddit") 
				{
					Talks(Balkanien() + " Reddit");
					Process.Start("https://reddit.com"); 
				}
				if(R == "Open Alibaba"||R == "Gary Alibaba"||R == "Gary open Alibaba")
				{ 
					Talks(Balkanien() + " Alibaba");
					Process.Start("https://www.alibaba.com");
				}
				if(R == "What is the color of Watermelon"||R == "Gary what is the color of Watermelon")
				{
					Talks("The color of Watermelon is green"); 
				}
				if(R =="What is the color of grapes"||R == "Gary what is the color of grapes")
				{
					Talks("The color of grapes is actually purple");
				}
				if(R == "Open Google Cloud Platforms"|| R == "Gary Open Google Cloud Platforms" || R == "Open Google Cloud Platform"||R == "Gary Open Google Cloud Platform"|| R == "Gary Google Cloud Platform"|| R == "Google Cloud Platforms"|| R == "Google Cloud Platform")
				{
					Talks(Balkanien()+" Google Cloud Platform");
					Process.Start("https://console.cloud.google.com/apis/"); 	
				}
				if(R == "Open tech crunch"||R == "Tech crunch"||R == "Gary open tech crunch")
				{
					Talks(Balkanien() + " Tech Crunch");
					Process.Start("https://techcrunch.com/");
				}
				if(R == "Open duck duck go"||R == "Gary open duck duck go"||R == "Duck duck go"||R == "Launch duck duck go"||R == "Duck duck go"||R == "Gary duck duck go")
				{
					Talks(Balkanien()+" "+"duck duck go");
					Process.Start("https://duckduckgo.com/");
				}
				if(R == "Tree"||R == "Gary tree") 
				{ 
					Process.Start("Ping.bat");
				}
				if(R == "Gary sing a rap song"||R=="Sing a rap song"||R == "Gary sing me a song")
				{
					Talks("This is what I have created myself");
					Talks(Rap());  
				}
				if (R == "How old are you" || R == "Gary how old are you" || R == "What is your age")
				{
					Talks("I am immortal but my birthday is at thirty first of august 2018 you can do your maths over here");
					Process.Start("https://www.google.com/search?source=hp&ei=mErlW7GZNoL1rQGz1quIDg&q=Calculator&oq=Calculator&gs_l=psy-ab.3..35i39k1j0j0i131k1l3j0l5.1045.2501.0.2650.11.9.0.0.0.0.273.1053.0j3j2.5.0....0...1c.1.64.psy-ab..6.5.1051.0...0.WKEhhFxzDRg");
				}
				if (R == "What is your name" || R == "Whats your name" || R == "Whats yer name")
				{
					Talks(Nhome());
				}
				if (R == "Gary open cool maths games" || R == "Gary open cool maths game" || R == "Open cool maths game" || R == "Open cool math gam/es" || R == "Gary cool math games")
				{
					Talks(Balkanien()+" cool maths game"); 
					Process.Start("https://www.coolmathgames.com");
				}
                if (R == "Open wikepedia" ||R == "Gary open wikepedia"||R == "Gary wikepedia")
                {
                    Talks(Balkanien()+" wikepedia");
                    Process.Start("https://www.wikipedia.org"); 
                }
                if(R == "Yandex maps"||R == "Yandex map"||R == "Gary yandex map" || R == "Open yandex maps"||R == "Gary open yandex map" || R == "Gary open yandex maps"||R == "Open yandex map")
                {
                    Talks(Balkanien()+" yandex map");  
                    Process.Start("https://yandex.ru/maps");
                }
                if(R == "Open google maps"||R == "Gary open google maps"||R == "Google map"||R == "Gary open google map" || R =="open google map"||R == "Gary google map"||R == "Gary google maps")
                {
                    Talks(Balkanien()+" google map");
                    Process.Start("https://www.google.com/maps");
                }
                if (R == "Open github" || R == "Gary open github" || R == "Launch github" || R == "Github" || R == "Gary github")
                {
                    Talks(Balkanien()+" Github");
                    Process.Start("https://github.com");
                }
                if (R == "Gary why you always lying" || R == "why you always lying")
                {
                    Talks("No it is you who are the liar");
                }
                if (R == "Open amazon" || R == "Amazon" || R == "Launch amazon" || R == "Gary open amazon" || R == "Gary amazon")
                {
                    Talks(Balkanien()+" Amazon");
                    Process.Start("https://www.amazon.com");
                }
                if (R == "Open dailymotion" || R == "Gary open dailymotion" || R == "Dailymotion" || R == "Dailymotion Gary")
                {
                    Talks(Balkanien()+" Dailymotion");
                    Process.Start("http://dailymotion.com");
                }
                if (R == "Open bing" || R == "Launch bing" || R == "Gary open bing" || R == "Bing" || R == "Gary bing")
                {
                    Talks(Balkanien()+" bing");
                    Process.Start("https://www.bing.com");
                }
                if (R == "Open baidu" || R == "Gary open baidu" || R == "Baidu" || R == "Gary kai baidu" || R == "kai baidu")
                {
                    Talks(Balkanien()+" opening Baidu");
                    Process.Start("http://www.baidu.com");
                }
                if (R == "Gary do you have a family" || R == "Gary do you have a family" ||R == "Do you have a family")
                { 
                    Talks("Yes my family is in Notchmods");
                }
                if (R == "Open Chess dot com" || R == "Gary open Chess dot com" || R == "Chess dot com")
                {
                    Talks(Balkanien()+" chess dot com");
                    Process.Start("https://www.chess.com/home");
                }
                if (R == "Open compass gary") 
                {
                    Process.Start("https://boxhillhs-vic.compass.education");
                }
                if (R == "Open msn" || R == "Gary Open msn" || R == "Msn")
                {
                    Talks(Balkanien()+" MSN");
                    Process.Start("http://msn.com");
                }
                if (R == "Calculator" ||R == "Open google calculator"||R == "Open calculator" || R == "Gary open calculator" || R == "Gary calculator")
                {
                    Talks(Balkanien()+" calculator"); 
                    Process.Start("https://www.google.com/search?source=hp&ei=o3ziW5vjH8btrQHTsZe4CA&q=Calculator&oq=Calculator&gs_l=psy-ab.3..35i39k1j0i131i67k1j0i131k1l2j0l2j0i131k1j0l2j0i131i67k1.3252.6596.0.6726.24.15.2.0.0.0.387.2276.0j1j7j1.9.0....0...1c.1.64.psy-ab..16.8.1561.0..0i131i20i263k1j0i10k1.0.HaEcj6otDtg");
                }
                if (R == "Who is jesus" || R == "Gary who is jesus")
                {
					Process.Start("https://www.google.com/search?q=Who+is+jesus&oq=Who+is+jesus&aqs=chrome..69i57j69i60l5.1778j0j1&sourceid=chrome&ie=UTF-8");
                }
                if (R == "Open discord" || R == "Gary open discord" || R == "discord"||R == "Launch discord")
                {
                    Talks("Joining discord server");
                    Process.Start("https://discordapp.com");
                }
                if(R == "your mum gay"||R  == "your fat")
                {
                    Talks("No you");
                }
                if (R == "Gary open google drive" || R == "Open google drive" || R == "Google drive")
                {
                    Talks(Balkanien()+" google drive");
                    Process.Start("https://drive.google.com/drive/u/0/");
                }
                if (R == "What is the date today" || R == "Todays date" || R == "Gary what is the date today" || R == "Gary what is today date" || R == "what is today date")
                {
                    Talks("Today is" + DateTime.Now.ToString("dd/M/yyyyy"));
                }
                if (R == "Open mathspace" || R == "Gary open mathspace" || R == "Mathspace")
                {
                    Talks(Balkanien()+" mathspace");
                    Process.Start("https://mathspace.co/student/");
                }
                if (R == "Gary stop" || R == "stop" || R == "shut up gary" || R == "Shut up")
                {
                    Notchmods.SpeakAsyncCancelAll();
                }
                if (R == "open gmail" || R == "Gary open gmail" || R == "Open google mail" || R == "Gary open google mail")
                {
                    Talks(Balkanien()+" gmail");
                    Process.Start("https://mail.google.com/mail/u/0/");
                }
                if (R == "Open twitter" || R == "Gary open twitter")
                {
                    Talks(Balkanien()+" Twitter");
                    Process.Start("https://twitter.com");
                }
                if (R == "What is the weather today" || R == "Gary what is the weather today" || R == "Whats the weather")
                { 
                    Talks("Here is the weather in your current location");
                    Process.Start("https://www.google.com/search?q=weather");
                }
                if (R == "Open youtube" || R == "Gary open youtube")
                {
                    Talks(Balkanien()+" Youtube");
                    Process.Start("https://www.youtube.com"); 
                }
                if (R == "Open teams" || R == "Gary open teams" || R == "Open microsoft teams" || R == "Gary open microsoft team")
                {
                    Talks(Balkanien()+" Microsoft teams");
                    Process.Start("https://teams.microsoft.com/go#");
                }
                if (R == "Close paint" || R == "Gary close paint")
                {
                    Talks("Yes I will close paint");
                    killprocysen("mspaint");
                }
                if (R == "Internet access authentication" || R == "Open internet access authentication" || R == "Gary open internet access authentication")
                {
                    Talks("Yes opening Internet Access Authentication");
                    Process.Start("https://auth.localnetwork.zone:60091/login");
                }
                if (R == "Open notchmods official website" || R == "Gary open notchmods official website")
                {
                    Talks("Opening up Notchmods website");
                    Process.Start("https://nomics3000.wixsite.com/notchmodsofficial");
                }
                if (R == "Open yandex translator" || R == "Gary open yandex translator" || R == "Yandex translator")
                {
                    Talks("Searching for Yandex Translator");
                    Process.Start("https://translate.yandex.com");
                }
                if (R == "Next" || R == "Gary next")
                {
                    SendKeys.Send("^{RIGHT}^");
                }
                if (R == "what is my ip address" || R == "what is the ip address" || R == "Gary what is the ip address" || R == "Gary what is my ip address")
                {
                    IPHostEntry Hawtsd;
                    string localEP = "?";
                    Hawtsd = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ep in Hawtsd.AddressList)
                    {
                        if (ep.AddressFamily.ToString() == "InterNetwork")
                        {
                            localEP = ep.ToString();
                            Talks(localEP);
                        }
                    }
                }
                if (R == "Open microsoft paint" || R == "open paint" || R == "Gary open paint" || R == "Gary open microsoft paint" || R == "Gary open ms paint" || R == " open ms paint")
                {
                    try
                    {
                        Talks("Opening Microsoft paint");
                        Process.Start("mspaint.exe");
                    }
                    catch
                    {
                        Talks("Sorry I have detected no files name ms paint dot exe mean while here is something related to paint");
                        Process.Start("https://paint-online.ru");
                    }
                }
                if (R == "Change color of this tab to yellow " || R == "Change the color to yellow" || R == "Gary Change color of this tab to yellow" || R == "Change the color on this tab to yellow")
                {
                    Talks("Changing this color to yellow");
                    this.BackColor = Color.Yellow;
                    
                }
                if (R == "Recommend me a song" || R == "song" || R == "Gary recommend me a song")
                {
                    Talks("Yes sure this song is the best I could find");
                    Process.Start(RLynxen());
                }
                if (R == "Just kidding" || R == "I am joking" || R == "I am sorry")
                {
                    Talks(ResSo());
                }
                if (R == "Gary you suck")
                {
                    Talks("No you suck");
                }
                if (R == "Open yandex mail" || R == "Gary open yandex mail" || R == "Yandex mail")
                {
                    Talks("Booting up yandex mail");
                    Process.Start("https://mail.yandex.com");
                }
                if (R == "open notepad" || R == "Gary open Notepad" || R == "Notepad open" || R == "Notepad" || R == "Gary notepad")
                {
                    try
                    {
                        Talks("Yes I will start notepad up");
                        Process.Start("notepad.exe");
                    }
                    catch
                    {
                        Talks("I am sorry you are missing a component called notepad dot exe");
                    }
                }
                if (R == "Tell me a joke" || R == "Gary tell me a joke" || R == "Tell me the best joke" || R == "Gary tell me the best jokes" || R == "jokes")
                {
                    Talks(Jawker());
                }
                if (R == "you gay" || R == "Gary is gay")
                {
                    Talks("No it is you who are gay");
                }
                if (R == "Open file explorers" || R == "open file" || R == "Gary open file" || R == "Gary open file explorers" || R == "check my files" || R == "Gary check my files")
                {
                    Talks("Yes I will open up file dialog");
                    OpenFileDialog Oaufde = new OpenFileDialog();
                    Oaufde.ShowDialog();
                }
                if (R == "Steam" || R == "Open Steam" || R == "Gary open steam")
                {
                    try
                    {
                        Talks("Launching steam");
                        Process.Start("Steam.exe");
                    }
                    catch
                    {
                        Process.Start("https://store.steampowered.com");
                    }
                }
                if (R == "Gary change the color on this tab to white" || R == "Gary change the color on this tab to the white color" || R == "change the color on this tab to white" || R == "change the color on this tab to white color")
                {
                    Talks("Changing it to the white color");
                    this.BackColor = Color.White;
                }
                if (R == "Gary change the color on this tab to aqua" || R == "Gary change the color on this tab to the default color" || R == "change the color on this tab to aqua" || R == "change the color on this tab to default color")
                {
                    Talks("Changing it to the default colors");
                    this.BackColor = Color.Aqua;
                }
                if (R == "Fuck you" || R == "Fuck you gary" || R == "Gary fuck you")
                {
                    Talks(SW());
                }
                if (R == "Gary change the color on this tab to blue" || R == "Gary change the color on this tab to blue" || R == "change the color on this tab to blue" || R == "change the color on this tab to blue")
                {
                    Talks("Changing it to blue");
                    this.BackColor = Color.Blue;
                }
                if (R == "open spotify" || R == "Gary open spotify" || R == "spotify"||R == "Launch spotify"||R == "Gary spotify") 
                {
                    try
                    {
                        Talks("Okay opening spotify");
                        Process.Start("Spotify.exe");
                    }
                    catch
                    {
                        Process.Start("https://play.spotify.com");
                    }
                }
                if (R == "open command prompt" || R == "Gary open command prompt" || R == "command prompt" || R == "cmd" || R == "Gary open cmd")
                {
                    try
                    {
                        Talks("opening command prompt");
                        Process.Start("cmd.exe");
                    }
                    catch
                    {
                        Talks("Check to make sure the file cmd dot exe exist");
                    }
                }
                if (R == "play" || R == "stop" || R == "pause")
                {
                    SendKeys.Send(" "); 
                }
                if (R == "Gary change the color on this tab to green" || R == "Gary change the color on this tab to lime" || R == "change the color on this tab to lime" || R == "change the color on this tab to green")
                {
                    Talks("Changing it to green");
                    this.BackColor = Color.Lime;
                }
                if (R == "Gary open instagram" || R == "open instagram")
                {
                    Talks(Balkanien()+" instagram");
                    Process.Start("https://www.instagram.com");
                }
                if (R == "Gary open facebook" || R == "open facebook" || R == "facebook")
                {
                    Talks(Balkanien()+" facebook");
                    Process.Start("https://www.facebook.com");
                }
                if (search)
                {
                    Process.Start("https://www.google.com/search?q=" + R);
                    search = false;
                }
                if (R == "search for" || R == "google" || R == "Gary search for")
                {
                    search = true;
                }
                if (R == "Open notchmods website" || R == "open Notchmod itch dot io website")
                {
                    Process.Start("https://notchmod.itch.io");
                }
                if (R == "Gary close this tab" || R == "close this tab")
                {
                    this.Close();
                }
                if (R == "Maximize this tab" || R == "Gary maximize this tab" || R == "Gary open this tab")
                {
                    Talks("Yes I will maximize it");
                    this.WindowState = FormWindowState.Maximized;
                }
                if (R == "Minimize this tab" || R == "Gary minimize this tab")
                {
                    Talks("Yes I will minimize it");
                    this.WindowState = FormWindowState.Minimized;
                }
                if (SD)
                {
                    if (R == "Now")
                    {
                        try
                        {
                            Talks("I will shutdown now");
                            Process.Start("shutdown.bat");
                            SD = false;
                        }
                        catch
                        {
                            Talks("I cannot detect a components for shutdown please make sure shutdown dot bat is not deleted");
                        }
                    }
                }
                if (R == "shutdown" || R == "Gary shutdown" || R == "Gary close this computer" || R == "Gary shut this computer down")
                {
                    SD = true;
                }
                if (R == "hello" || R == "Hi" || R == "Hi how are you" || R == "Hi gary" || R == "Hello gary")
                {
                    Talks(Harrow());
                }

                if (R == "what time is it now" || R == "whats the time now" || R == "What is the time now" || R == "What is the time" || R == "Gary what time is it now")
                {
                    Talks("The time now is" + " " + DateTime.Now.ToString("h mm tt"));
                }
                if (R == "open yandex" || R == "Gary open yandex" || R == "yandex")
                { 
                    try
                    {
                        Talks("yandex is ready");
                        Process.Start("browser.exe");
                    }
                    catch
                    {
                        Process.Start("https://www.yandex.com");
                    }
                }
                if (R == "open google" || R == "Gary open google" || R == "Gary google"||R == "Launch google") 
                {
                    try
                    {
                        Talks("yes I will open google");
                        Process.Start("chrome.exe");
                    }
                    catch
                    {
                        Process.Start("https://google.com");
                    }
                }
                textBox1.AppendText(R + "\n");
                if (R == "cancel shutdown" || R == "stop the shutdown")
                {
                    Talks("Yes I will cancel it");
                    SD = false;
                }
            }
        } 
        //Load without getting system error
        private void Form1_Load(object sender, EventArgs e)
        {
            Notchmods.Rate = trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm:ss");
            label6.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
