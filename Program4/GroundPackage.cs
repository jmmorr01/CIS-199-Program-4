using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    public class GroundPackage
    {
        public const int MIN_ZIP = 00000; // Minimum zip code that can be entered
        public const int MAX_ZIP = 99999; // Maximum zip code that can be entered
        public const int MIN_INCHES = 0; // Minimum inches allowed for package height/length/width
        public const int MIN_WEIGHT = 0; // Minimum weight allowed for package

        private int originZipCode; // the original zip code for package
        private int destinationZipCode; // the destination zip code for package
        private double lengthInches; // the length in inches of package
        private double widthInches; // the width in inches of package
        private double heightInches; // the height in inches of package
        private double weight; // the weight of package
        private double cost; // the cost of package
        private int defaultOrigin = 40202; // default origin zip code
        private int defaultDestination = 90210; // default destination zip code
        private int defaultDimension = 1; // default number for dimensions of package 
        private int distanceDivider = 10000; // number used to find first digit of zip code

        // Precondition: All preconditions after this are met.
        // Postcondition: Package will be initalized will the information entered.
        public GroundPackage(int originationZip, int destinationZip, double length, double width,
            double height, double weightPounds)
        {
            OriginZip = originationZip;
            DestinationZip = destinationZip;
            Length = length;
            Width = width;
            Height = height;
            Weight = weightPounds;
        }
        public int OriginZip
        {
            // Precondition: None
            // Postcondition: The zip code will be returned.
            get
            {
                return originZipCode;
            }

            // Precondition: 00000 < value < 99999
            // Postcondition: The zip code had been set.
            set
            {
                if ((value > MIN_ZIP) && (value < MAX_ZIP))
                    originZipCode = value;
                else originZipCode = defaultOrigin;
            }
        }
        public int DestinationZip
        {
            // Precondition: None
            // Postcondition: The zip code will be returned.
            get
            {
                return destinationZipCode;
            }

            // Precondition: 00000 < value < 99999
            // Postcondition: Zip code will be set.
            set
            {
                if ((value > MIN_ZIP) && (value < MAX_ZIP))
                    destinationZipCode = value;
                else destinationZipCode = defaultDestination;
            }
        }
        public double Length
        {
            // Precondition: None
            // Postcondition: Length will be returned.
            get
            {
                return lengthInches;
            }

            // Precondition: value > 0
            // Postcondition: Length will be set
            set
            {
                if (value > MIN_INCHES)
                    lengthInches = value;
                else lengthInches = defaultDimension;
            }
        }
        public double Width
        {
            // Precondition: None
            // Postcondition: width will be returned.
            get
            {
                return widthInches;
            }

            // Precondition: value > 0
            // Postcondition: Width will be set.
            set
            {
                if (value > MIN_INCHES)
                    widthInches = value;
                else widthInches = defaultDimension;
            }
        }
        public double Height
        {
            // Precondition: None
            // Postcondition: Height will be returned.
            get
            {
                return heightInches;
            }

            // Precondition: value > 0
            // Postcondition: Height will be set
            set
            {
                if (value > MIN_INCHES)
                    heightInches = value;
                else heightInches = defaultDimension;
            }
        }
        public double Weight
        {
            // Precondition: None
            // Postcondition: Weight will be returned.
            get
            {
                return weight;
            }

            // Precondition: value > 0
            // Postcondition: Weight will be set.
            set
            {
                if (value > MIN_WEIGHT)
                    weight = value;
                else weight = defaultDimension;
            }
        }
        public int ZoneDistance
        {
            // Precondition: None
            // Postcondition: Returns the zone distance of the positive number difference between the first two digits of the zip codes.
            get
            {
                return (originZipCode / distanceDivider) - (destinationZipCode / distanceDivider);
            }

        }
        public double CalcCost()
        {
            // Precondition: All variables have received valid input.
            // PostCondition: Cost will be returned.
            
            return cost = (.20 * (Length + Width + Height)) + (.5 * (ZoneDistance + 1) * (Weight));
        }
        public override string ToString()
        {
            // Precondition: All previous preconditions have been met.
            // Postcondition: Returns a string that contains details of the pacakge.
            return "Origin Zip Code: " + originZipCode.ToString() + System.Environment.NewLine +
                "Destination Zip Code: " + destinationZipCode.ToString() + System.Environment.NewLine +
                "Length: " + lengthInches.ToString() + System.Environment.NewLine +
                "Width: " + widthInches.ToString() + System.Environment.NewLine +
                "Height: " + heightInches.ToString() + System.Environment.NewLine +
                "Weight: " + weight.ToString() + System.Environment.NewLine
                + "Cost: " + cost.ToString("c");
        }
    }
}
