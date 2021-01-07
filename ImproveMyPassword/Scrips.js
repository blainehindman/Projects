$(document).ready(function(){

    $("#Password_Input").on("input", function(){
        //Variables for The users input password and its length
        var Input_Password = $("#Password_Input").val();
        var Password_length = Input_Password.length;
        //Variables for The Entered Password
        var Special_Count = -1;
        var Numbers_Count = -1;
        var Caps_Count = -1;
        //Arrays
        var Special_Characters_Array = ["!", "@", "#", "%", "^", "&", "*", "(", ")", "-", "_", "-", "+", "="];
        var Numbers_Array = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];
        var Caps_Array = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        //New Sub variables for Specials, numbers and caps
        var Sub_Special = "";
        var Sub_Numbers = "";
        var Sub_Caps = "";

        //Input base password is less then 6 characters
        if(Password_length < 6)
        {
            //Show length message
            $("#Required_Length").show();
            //Hide Suggestion Message
            $("#Password_Suggestions").hide();
            //Hide Suggested Password in case of backspace
            $("#S_1").empty();
            $("#S_2").empty();
            $("#S_3").empty();
        }
        //Input base password is at least 6 characters
        else
        {
            //Hide length message
            $("#Required_Length").hide();
            //Show Suggestion Message
            $("#Password_Suggestions").show();


            //Function to count Special Characters
            $(function(){

                for(var i=0; i <= Input_Password.length; i++)
                {
                    for(var j=0; j<= Special_Characters_Array.length; j++)
                    {
                        if(Input_Password[i] == Special_Characters_Array[j])
                        {
                            Special_Count++;
                        }
                    }
                }
                console.log("Special Count: " + Special_Count);
            });

            //Function to count Numbers
            $(function(){

                for(var i=0; i <= Input_Password.length; i++)
                {
                    for(var j=0; j<= Numbers_Array.length; j++)
                    {
                        if(Input_Password[i] == Numbers_Array[j])
                        {
                            Numbers_Count++;
                        }
                    }
                }
                console.log("Numbers Count: " + Numbers_Count);
            });

            //Function to count Caps
            $(function(){

                for(var i=0; i <= Input_Password.length; i++)
                {
                    for(var j=0; j<= Caps_Array.length; j++)
                    {
                        if(Input_Password[i] == Caps_Array[j])
                        {
                            Caps_Count++;
                        }
                    }
                }
                console.log("Caps Count: " + Caps_Count);
            });

            ///
            ///The special, characters, and numbers have all been tallied
            ///

            //Function to suggest "Good" Password
            $(function(){

                ///
                ///Check And Append Special Characters
                ///
                if(Special_Count == 0)
                {
                    console.log("2 More Special Characters Needed")
                    //Randomly Generate 2 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 1)
                {
                    console.log("1 More Special Characters Needed")
                    //Randomly Generate 1 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count >= 2)
                {
                    console.log("No More Special Characters Needed")
                }
                ///
                ///Check And Append Numbers
                ///
                if(Numbers_Count == 0)
                {
                    console.log("2 More Numbers Needed")
                    //Randomly Generate 2 Numbers and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 1)
                {
                    console.log("1 More Numbers Needed")
                    //Randomly Generate 1 Numbers and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count >= 2)
                {
                    console.log("No More Numbers Needed");
                }
                ///
                ///Check And Append Caps
                ///
                if(Caps_Count == 0)
                {
                    console.log("2 More Caps Needed")
                    //Randomly Generate 2 Caps and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 1)
                {
                    console.log("1 More Caps Needed")
                    //Randomly Generate 1 Caps and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count >= 2)
                {
                    console.log("No More Caps Needed");
                }

                ///
                ///All Generation is Done, now we need to append the sub variables back into the base Password
                ///
                var Suggestion_1 = Sub_Numbers + Input_Password + Sub_Special + Sub_Caps;
                //check if undefined slipped in and remove
                if(Suggestion_1.includes("undefined"))
                {
                    while (Suggestion_1.includes("undefined"))
                    {
                        Suggestion_1 = Suggestion_1.replace('undefined','');
                    }
                }
                console.log("Suggested Good Password: " + Suggestion_1);

                //Add to HTML
                $("#S_1").empty();
                $("#S_1").append("Good Password: " + "<b>" + Suggestion_1 + "</b>");
            });

            //Function to suggest "Great" Password
            $(function(){

                //clear Sub Variables so there is no carry over
                Sub_Special = "";
                Sub_Numbers = "";
                Sub_Caps = "";

                ///
                ///Check And Append Special Characters
                ///
                if(Special_Count == 0)
                {
                    console.log("3 More Special Characters Needed")
                    //Randomly Generate 3 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 1)
                {
                    console.log("2 More Special Characters Needed")
                    //Randomly Generate 2 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 2)
                {
                    console.log("1 More Special Character Needed")
                    //Randomly Generate 1 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count >= 3)
                {
                    console.log("No More Special Characters Needed")
                }

                ///
                ///Check And Append Numbers
                ///
                if(Numbers_Count == 0)
                {
                    console.log("3 More Numbers Needed")
                    //Randomly Generate 3 Numbers and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 1)
                {
                    console.log("2 More Numbers Needed")
                    //Randomly Generate 2 Numbers and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 2)
                {
                    console.log("1 More Number Needed")
                    //Randomly Generate 1 Numbers and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count >= 3)
                {
                    console.log("No More Numbers Needed");
                }
                ///
                ///Check And Append Caps
                ///
                if(Caps_Count == 0)
                {
                    console.log("3 More Caps Needed")
                    //Randomly Generate 3 Caps and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 1)
                {
                    console.log("2 More Caps Needed")
                    //Randomly Generate 2 Caps and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 2)
                {
                    console.log("1 More Cap Needed")
                    //Randomly Generate 1 Caps and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count >= 3)
                {
                    console.log("No More Caps Needed");
                }

                ///
                ///All Generation is Done, now we need to append the sub variables back into the base Password
                ///
                var Suggestion_2 = Sub_Caps + Sub_Numbers + Input_Password + Sub_Special;
                //check if undefined slipped in and remove
                if(Suggestion_2.includes("undefined"))
                {
                    while (Suggestion_2.includes("undefined"))
                    {
                        Suggestion_2 = Suggestion_2.replace('undefined','');
                    }
                }
                console.log("Suggested Good Password: " + Suggestion_2);

                //Add to HTML
                $("#S_2").empty();
                $("#S_2").append("Great Password: " + "<b>" + Suggestion_2 + "</b>");
            });


            //Function to suggest "Amazing" Password
            $(function(){

                //clear Sub Variables so there is no carry over
                Sub_Special = "";
                Sub_Numbers = "";
                Sub_Caps = "";

                ///
                ///Check And Append Special Characters
                ///
                if(Special_Count == 0)
                {
                    console.log("4 More Special Characters Needed")
                    //Randomly Generate 4 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 3; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 1)
                {
                    console.log("3 More Special Characters Needed")
                    //Randomly Generate 3 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 2)
                {
                    console.log("2 More Special Character Needed")
                    //Randomly Generate 2 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count == 3)
                {
                    console.log("1 More Special Character Needed")
                    //Randomly Generate 1 Special Characters and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var S = Special_Characters_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Special = Sub_Special + S;
                    }
                    console.log("Sub_Special: " + Sub_Special);
                }
                if(Special_Count >= 4)
                {
                    console.log("No More Special Characters Needed")
                }

                ///
                ///Check And Append Numbers
                ///
                if(Numbers_Count == 0)
                {
                    console.log("4 More Numbers Needed")
                    //Randomly Generate 4 Numbers and append them to Sub variable
                    for(var i = 0; i <= 3; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 1)
                {
                    console.log("3 More Numbers Needed")
                    //Randomly Generate 3 Numbers and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 2)
                {
                    console.log("2 More Number Needed")
                    //Randomly Generate 2 Numbers and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count == 3)
                {
                    console.log("1 More Number Needed")
                    //Randomly Generate 1 Numbers and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var N = Numbers_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Numbers = Sub_Numbers + N;
                    }
                    console.log("Sub_Numbers: " + Sub_Numbers);
                }
                if(Numbers_Count >= 4)
                {
                    console.log("No More Numbers Needed");
                }
                ///
                ///Check And Append Caps
                ///
                if(Caps_Count == 0)
                {
                    console.log("4 More Caps Needed")
                    //Randomly Generate 4 Caps and append them to Sub variable
                    for(var i = 0; i <= 3; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 1)
                {
                    console.log("3 More Caps Needed")
                    //Randomly Generate 3 Caps and append them to Sub variable
                    for(var i = 0; i <= 2; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 2)
                {
                    console.log("2 More Cap Needed")
                    //Randomly Generate 2 Caps and append them to Sub variable
                    for(var i = 0; i <= 1; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count == 3)
                {
                    console.log("1 More Cap Needed")
                    //Randomly Generate 1 Caps and append them to Sub variable
                    for(var i = 0; i <= 0; i++)
                    {
                        var C = Caps_Array[Math.floor(Math.random() * Password_length)];
                        Sub_Caps = Sub_Caps + C;
                    }
                    console.log("Sub_Caps: " + Sub_Caps);
                }
                if(Caps_Count >= 4)
                {
                    console.log("No More Caps Needed");
                }

                ///
                ///All Generation is Done, now we need to append the sub variables back into the base Password
                ///
                var Suggestion_3 = Sub_Special + Sub_Numbers + Input_Password + Sub_Caps;
                //check if undefined slipped in and remove
                if(Suggestion_3.includes("undefined"))
                {
                    while (Suggestion_3.includes("undefined"))
                    {
                        Suggestion_3 = Suggestion_3.replace('undefined','');
                    }
                }

                console.log("Suggested Amazing Password: " + Suggestion_3);
                //Add to HTML
                $("#S_3").empty();
                $("#S_3").append("Amazing Password: " + "<b>" + Suggestion_3 + "</b>");
            });
        }
    });
});
