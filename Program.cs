//Convert twos complement floating point binary number into denary

using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    //Global Variable Declaration
    string inpS = "";//Temporary var for user input
    var mantissa = new List<int>();
    var exponent = new List<int>();
    bool negMantissa = false;
    bool negExponent = false;
    bool done = false;//General bool used to controll while loops
    int i = 0;//General int used to count iterations
    int binPoint = 0;//Denotes the location of the binary point
    int exp = 0;
    double totalInt = 0;
    double totalDec = 0;
    double total = 0;
    double val = 0;
    int mantLen = 0;
    int expLen = 0;
    bool valid = false;
    
    //Take and validate input
    while(valid != true){
      Console.WriteLine("Enter a binary number : ");
      inpS = inputS();
      Console.WriteLine("Enter the length of the mantissa : ");
      mantLen = inputI();
      Console.WriteLine("Enter the length of the exponent : ");
      expLen = inputI();
      if(mantLen + expLen == inpS.Length){
        valid = true;
      }
    }

    //Checks for specific case when the mantissa is 0
    if(Convert.ToInt32(inpS.Substring(0,mantLen)) == 0){
      Console.WriteLine("0");
      return;
    }

    //Split into lists
    foreach(char character in inpS.Substring(0,mantLen)){
      mantissa.Add(Convert.ToInt32(character.ToString()));
    }
    foreach(char character in inpS.Substring(mantLen,expLen)){
      exponent.Add(Convert.ToInt32(character.ToString()));
    }

    //identify negatives and call relevant subroutines
    if(mantissa[0] == 1){
      negMantissa = true;
      mantissa = twoCompliment(mantissa);
    }
    if(exponent[0] == 1){
      negExponent = true;
      exponent = twoCompliment(exponent);
    }

    //Find the first 1 in mantissa
    i = 0;
    done = false;
    while(done == false){
      if(mantissa[i] == 1){
        binPoint = i;
        done = true;
      }
      i++;
    }

    //get num value of exponent
    val = 1;
    for(i = exponent.Count - 1; i >= 0; i--){
      exp += Convert.ToInt32(exponent[i] * val);
      val *= 2;
    }

    //Find position of binary point and move it as appropriate
    if(negExponent == true){
      if(binPoint - exp >= 0){
        binPoint -= exp;
      }
      else{
        exp -= binPoint;
        binPoint = 0;
        for(i = 0; i < exp; i++){
          mantissa.Insert(0,0);
        }
      }
    }
    else{
      if(binPoint + exp < mantissa.Count){
        binPoint += exp;
      }
      else{
        exp = exp - (mantissa.Count-1-binPoint);
        for(i = 0; i < exp; i++){
          mantissa.Add(0);
        }
      }
    }

    //Convert int section of mantissa to base 10
    val = 1;
    for(i = binPoint - 1; i >= 0; i--){
      totalInt += Convert.ToInt32(mantissa[i]) * val;
      val *= 2;
    }

    //Convert bin section of mantissa to base 10
    val = 0.5;
    for(i = binPoint; i < mantissa.Count; i++){
      totalDec += Convert.ToInt32(mantissa[i]) * val;
      val /= 2;
    }

    //Find and output total sum
    total = totalInt + totalDec;
    if(negMantissa == true){
      total = 0 - total;
    }
    Console.WriteLine(total);
    
  }
  static string inputS(){ //Takes and validates a string input
    string input = "";
    bool valid = false;
    while(valid != true){
      input = Console.ReadLine();
      valid = true;
      for(int i = 0; i < input.Length; i++){
        if((input[i] != '0')&&(input[i] != '1')){
          valid = false;
        }
      }
    }
    return input;
  }

  static List<int> twoCompliment(List<int> inp){ //Performs two's compliment
    var ans = new List<int>();
    bool done = false;
    foreach(int num in inp){
      if(num == 0){
        ans.Add(1);
      }
      else{
        ans.Add(0);
      }
    }
    int i = ans.Count - 1;
    while(done == false){
      if(ans[i]==0){
        ans[i] = 1;
        done = true;
      }
      i--;
    }
    return ans;
  }

  static int inputI(){ //Takes and validates integer input
    int inp = 0;
    bool valid = false;
    while(valid != true){
      try{
        inp = Convert.ToInt32(Console.ReadLine());
        if(inp > 0){
          valid = true;
        }
      }
      catch(System.FormatException){
        Console.WriteLine("Data input must be integer !!!");
      }
    }
    return inp;
  }
}