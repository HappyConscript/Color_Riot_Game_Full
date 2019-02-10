/*
 * Company: Molotov Industries
 * Author: Evan Brooks
 * Date: 12-15-2018
 * Project: Color Riot
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * _____________________________________________________________________________________________________________________________________________________
 * Class to create 'Item' object
 * Item
 */

public class Item {

	/*
	 * _____________________________________________________________________________________________________________________________________________________
	 * Attributes
	 */

	public string objekt { get; set; }
	public string color { get; set; }

	System.Random random = new System.Random();

	List<string> objektList = new List<string>();
	List<string> colorList = new List<string>();

	/*
     * _____________________________________________________________________________________________________________________________________________________
     * Constructor
     */

	public Item(string objekt, string color)
	{
		this.objekt = objekt;
		this.color = color;
	}

	/*
     * _____________________________________________________________________________________________________________________________________________________
     * Behaviors
     */

	public override string ToString() //Debug string with relevant attributes
	{
		string print = color + " " + objekt;
		return print;
	}

	public void RandSetup() //Initialize rand integer and generate rand numbers
	{
		int randObjekt = 0;
		int randColor = 0;

		//Set rand = to an item in lists between their max and min indices
		randObjekt = random.Next(0, objektList.Count - 1);
		randColor = random.Next(0, colorList.Count - 1);

		//Use the rand to pull object and color info from lists
		objekt = objektList[randObjekt];
		color = colorList[randColor];
	}

	public void ItemSetup() //Populates objekt and color lists
	{
		//Debug
		Debug.Log("Populating objektList");

		//Furniture
		objektList.Add("Desk");
		objektList.Add("Table");
		objektList.Add("Chair");
		objektList.Add("Sofa");
		objektList.Add("Shelf");
		objektList.Add("Bench");
		objektList.Add("Stool");
		objektList.Add("Dresser");
		objektList.Add("Chest");
		objektList.Add("Rug");
		objektList.Add("Doormat");
		objektList.Add("Lamp");
		objektList.Add("Poster");
		objektList.Add("Frame");
		objektList.Add("Recliner");
		objektList.Add("Bed");
		objektList.Add("Beanbag");
		objektList.Add("Hammock");
		objektList.Add("Toilet");
		objektList.Add("Tub");
		objektList.Add("Shower");

		//House
		objektList.Add("Window");
		objektList.Add("Roof");
		objektList.Add("Wall");
		objektList.Add("Floor");
		objektList.Add("House");
		objektList.Add("Apartment");
		objektList.Add("Condo");
		objektList.Add("Door");
		objektList.Add("Garage");
		objektList.Add("Carpet");
		objektList.Add("Bedroom");
		objektList.Add("Bathroom");
		objektList.Add("Kitchen");
		objektList.Add("Stairs");
		objektList.Add("Porch");

		//Office
		objektList.Add("Pen");
		objektList.Add("Pencil");
		objektList.Add("Marker");
		objektList.Add("Chalk");
		objektList.Add("Stapler");
		objektList.Add("Tape");
		objektList.Add("Paper");
		objektList.Add("Notebook");
		objektList.Add("Binder");
		objektList.Add("Paperclip");
		objektList.Add("Stickynote");
		objektList.Add("Scissors");
		objektList.Add("Highlighter");
		objektList.Add("Folder");

		//Places
		objektList.Add("Cafe");
		objektList.Add("Library");
		objektList.Add("Airport");
		objektList.Add("School");
		objektList.Add("Store");
		objektList.Add("Mall");
		objektList.Add("Park");
		objektList.Add("Restaurant");
		objektList.Add("City");
		objektList.Add("Town");
		objektList.Add("Office");
		objektList.Add("Windmill");
		objektList.Add("Barn");
		objektList.Add("Stable");
		objektList.Add("Factory");
		objektList.Add("Temple");
		objektList.Add("Spa");
		objektList.Add("Gym");
		objektList.Add("Museum");
		objektList.Add("Gallary");
		objektList.Add("Arcade");
		objektList.Add("Hotel");
		objektList.Add("Resort");
		objektList.Add("Motel");
		objektList.Add("Castle");
		objektList.Add("Fort");
		objektList.Add("Shrine");
		objektList.Add("Dock");
		objektList.Add("Boardwalk");
		objektList.Add("Pier");
		objektList.Add("Cabin");
		objektList.Add("Shack");
		objektList.Add("Jail");
		objektList.Add("Prison");
		objektList.Add("Hospital");
		objektList.Add("Clinic");
		objektList.Add("Bar");
		objektList.Add("Arena");
		objektList.Add("Stadium");
		objektList.Add("Office");

		//Transport
		objektList.Add("Car");
		objektList.Add("Plane");
		objektList.Add("Train");
		objektList.Add("Boat");
		objektList.Add("Motorcycle");
		objektList.Add("Moped");
		objektList.Add("Helicopter");
		objektList.Add("Truck");
		objektList.Add("Bus");
		objektList.Add("Trailer");
		objektList.Add("Bicycle");
		objektList.Add("Skateboard");
		objektList.Add("Snowboard");
		objektList.Add("Sidewalk");
		objektList.Add("Road");
		objektList.Add("Bridge");
		objektList.Add("Tunnel");
		objektList.Add("Highway");
		objektList.Add("Track");
		objektList.Add("Subway");

		//Animals
		objektList.Add("Elephant");
		objektList.Add("Giraffe");
		objektList.Add("Lion");
		objektList.Add("Bear");
		objektList.Add("Unicorn");
		objektList.Add("Dog");
		objektList.Add("Cat");
		objektList.Add("Hamster");
		objektList.Add("Bird");
		objektList.Add("Unicorn");
		objektList.Add("Narwhal");
		objektList.Add("Snake");
		objektList.Add("Lizard");
		objektList.Add("Spider");
		objektList.Add("Shark");
		objektList.Add("Whale");
		objektList.Add("Dolphin");
		objektList.Add("Horse");
		objektList.Add("Pig");
		objektList.Add("Chicken");
		objektList.Add("Goat");
		objektList.Add("Turtle");
		objektList.Add("Frog");
		objektList.Add("Deer");
		objektList.Add("Rabbit");
		objektList.Add("Squirrel");
		objektList.Add("Gecko");
		objektList.Add("Dragon");
		objektList.Add("Yeti");
		objektList.Add("Llama");
		objektList.Add("Otter");
		objektList.Add("Octopus");
		objektList.Add("Jellyfish");
		objektList.Add("Eel");
		objektList.Add("Caterpillar");
		objektList.Add("Worm");
		objektList.Add("Beetle");
		objektList.Add("Centipede");
		objektList.Add("Walrus");
		objektList.Add("Wolf");

		//Technology
		objektList.Add("Computer");
		objektList.Add("Keyboard");
		objektList.Add("Speakers");
		objektList.Add("Phone");
		objektList.Add("Tablet");
		objektList.Add("Printer");
		objektList.Add("Television");
		objektList.Add("Camera");
		objektList.Add("Headphones");
		objektList.Add("Microphone");
		objektList.Add("Lightbulb");
		objektList.Add("Controller");
		objektList.Add("Battery");
		objektList.Add("Remote");
		objektList.Add("Clock");
		objektList.Add("Webcam");
		objektList.Add("Charger");
		objektList.Add("Router");

		//Tools
		objektList.Add("Hammer");
		objektList.Add("Wrench");
		objektList.Add("Shovel");
		objektList.Add("Saw");
		objektList.Add("Broom");
		objektList.Add("Mop");
		objektList.Add("Duster");
		objektList.Add("Screwdriver");
		objektList.Add("Hatchet");
		objektList.Add("Nail");
		objektList.Add("Screw");
		objektList.Add("Sponge");
		objektList.Add("Vaccuum");
		objektList.Add("Drill");
		objektList.Add("Rag");
		objektList.Add("Plunger");
		objektList.Add("Crowbar");
		objektList.Add("Pickaxe");
		objektList.Add("Axe");
		objektList.Add("Chainsaw");

		//Clothing
		objektList.Add("Hat");
		objektList.Add("Scarf");
		objektList.Add("Gloves");
		objektList.Add("Watch");
		objektList.Add("Glasses");
		objektList.Add("Shirt");
		objektList.Add("Jeans");
		objektList.Add("Shorts");
		objektList.Add("Swimsuit");
		objektList.Add("Jacket");
		objektList.Add("Bracelet");
		objektList.Add("Necklace");
		objektList.Add("Ring");
		objektList.Add("Socks");
		objektList.Add("Skirt");
		objektList.Add("Dress");
		objektList.Add("Tights");
		objektList.Add("Undies");
		objektList.Add("Belt");
		objektList.Add("Suit");
		objektList.Add("Sweater");
		objektList.Add("Shawl");
		objektList.Add("Beanie");
		objektList.Add("Earmuffs");
		objektList.Add("Shoes");
		objektList.Add("Sandals");
		objektList.Add("Boots");

		//Recreation
		objektList.Add("Book");
		objektList.Add("Puck");
		objektList.Add("Football");
		objektList.Add("Baseball");
		objektList.Add("Tennisball");
		objektList.Add("Basketball");
		objektList.Add("Soccerball");
		objektList.Add("Birdie");
		objektList.Add("Plushie");
		objektList.Add("Racket");
		objektList.Add("Plushie");
		objektList.Add("Block");
		objektList.Add("Doll");
		objektList.Add("Dart");
		objektList.Add("Dumbbell");
		objektList.Add("Treadmill");

		//Nature
		objektList.Add("Tree");
		objektList.Add("Bush");
		objektList.Add("Flower");
		objektList.Add("Seed");
		objektList.Add("Mushroom");
		objektList.Add("Sky");
		objektList.Add("Water");
		objektList.Add("Ocean");
		objektList.Add("Rock");
		objektList.Add("Lake");
		objektList.Add("Pond");
		objektList.Add("Field");
		objektList.Add("Cloud");
		objektList.Add("Grass");
		objektList.Add("Dirt");
		objektList.Add("Mud");
		objektList.Add("Leaf");
		objektList.Add("Sand");
		objektList.Add("Coral");
		objektList.Add("Fungus");
		objektList.Add("Mountain");
		objektList.Add("Beach");
		objektList.Add("Valley");
		objektList.Add("Canyon");

		//Food
		objektList.Add("Plate");
		objektList.Add("Bowl");
		objektList.Add("Cup");
		objektList.Add("Napkin");
		objektList.Add("Pot");
		objektList.Add("Pan");
		objektList.Add("Skillet");
		objektList.Add("Kettle");
		objektList.Add("Blender");
		objektList.Add("Knife");
		objektList.Add("Fork");
		objektList.Add("Spoon");
		objektList.Add("Chopsticks");
		objektList.Add("Spatula");
		objektList.Add("Bread");
		objektList.Add("Fridge");
		objektList.Add("Oven");
		objektList.Add("Stove");
		objektList.Add("Microwave");
		objektList.Add("Freezer");
		objektList.Add("Sink");
		objektList.Add("Cake");
		objektList.Add("Pie");
		objektList.Add("Taco");
		objektList.Add("Burger");
		objektList.Add("Sandwhich");
		objektList.Add("Soup");
		objektList.Add("Jelly");
		objektList.Add("Soda");
		objektList.Add("Noodles");
		objektList.Add("Jar");
		objektList.Add("Bottle");
		objektList.Add("Can");
		objektList.Add("Soup");
		objektList.Add("Dumpling");
		objektList.Add("Icecream");
		objektList.Add("Pancake");
		objektList.Add("Waffle");
		objektList.Add("Toaster");
		objektList.Add("Whisk");
		objektList.Add("Juicer");
		objektList.Add("Pizza");
		objektList.Add("Steak");
		objektList.Add("Corn");
		objektList.Add("Carrot");
		objektList.Add("Lettuce");
		objektList.Add("Onion");
		objektList.Add("Berry");
		objektList.Add("Melon");

		//Misc
		objektList.Add("Trashcan");
		objektList.Add("Key");
		objektList.Add("Towel");

		//Debug
		Debug.Log("Objekt Count: " + objektList.Count.ToString());
		Debug.Log("Populating colorList");

		//Colors
		colorList.Add("Red");
		colorList.Add("Orange");
		colorList.Add("Yellow");
		colorList.Add("Green");
		colorList.Add("Blue");
		colorList.Add("Purple");
		colorList.Add("Pink");
		colorList.Add("Gray");
		colorList.Add("Brown");
		colorList.Add("White");
		colorList.Add("Black");

		//Debug
		Debug.Log("Color Count: " + colorList.Count.ToString());
	}

	public void FancyColorsSetup()
	{
		colorList.Add("Bronze");
		colorList.Add("Silver");
		colorList.Add("Gold");
		colorList.Add("Platinum");
		colorList.Add("Beige");
		colorList.Add("Turquoise");
		colorList.Add("Lavender");
		colorList.Add("Magenta");
		colorList.Add("Fuchsia");
		colorList.Add("Maroon");
		colorList.Add("Violet");
	}

	public void FancyColorsRemove()
	{
		colorList.Remove("Bronze");
		colorList.Remove("Silver");
		colorList.Remove("Gold");
		colorList.Remove("Platinum");
		colorList.Remove("Beige");
		colorList.Remove("Turquoise");
		colorList.Remove("Lavender");
		colorList.Remove("Magenta");
		colorList.Remove("Fuchsia");
		colorList.Remove("Maroon");
		colorList.Remove("Violet");
	}

	public void FancierColorsSetup()
	{
		colorList.Add("Burgundy");
		colorList.Add("Periwinkle");
		colorList.Add("Cerulean");
		colorList.Add("Aureolin");
		colorList.Add("Viridian");
		colorList.Add("Obsidian");
		colorList.Add("Persimmon");
		colorList.Add("Chartreuse");
		colorList.Add("Razzmatazz");
		colorList.Add("Heliotrope");
		colorList.Add("Amaranth");
		colorList.Add("Celadon");
	}

	public void FancierColorsRemove()
	{
		colorList.Remove("Burgundy");
		colorList.Remove("Periwinkle");
		colorList.Remove("Cerulean");
		colorList.Remove("Aureolin");
		colorList.Remove("Viridian");
		colorList.Remove("Obsidian");
		colorList.Remove("Persimmon");
		colorList.Remove("Chartreuse");
		colorList.Remove("Razzmatazz");
		colorList.Remove("Heliotrope");
		colorList.Remove("Amaranth");
		colorList.Remove("Celadon");
	}
}
