using System;

public class TextInput {
    protected string inputValue;
    
    public TextInput() {
        inputValue = "";
    }
    
    public virtual void Add(char a) {
        //Console.WriteLine("TextInput");
        inputValue = inputValue + a;
    }
    
    public string GetValue() {
        return inputValue;
    }
    
}

public class NumericInput : TextInput {
    
    public NumericInput() {
        inputValue = "";
    }
    
    public override void Add(char a) {
        //Console.WriteLine("NumericInput");
        if (Char.IsNumber(a)) {
            inputValue = inputValue + a;
        }
    }
}

public class UserInput
{
    public static void Main(string[] args)
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}