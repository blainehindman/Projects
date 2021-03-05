import discord
import os
from keep_alive import keep_alive

#contact discord client
client = discord.Client()

#Read bad words List
def Read_Wordlist(fileName):
        fileObj = open(fileName, "r") #opens the file in read mode
        words = fileObj.read().splitlines() #puts the file into an array
        fileObj.close()
        return words

#read badwords into object 
Bad_Words = Read_Wordlist("wordlist.txt")

#read Server Positivity Score from file
def Read_Sscore(filename):
    with open(filename) as f:
        Sscore_List = [int(x) for x in f]
        return Sscore_List[0]

#print verfied connection
@client.event
async def on_ready():
    print('We have logged in as {0.user}'.format(client))

#await message from user
@client.event
async def on_message(message):
    #set local msg variable
    msg = message.content

    #set message to lower case
    msg = msg.lower()

    #read Server Positivity Score from function
    Server_Positivity_Score = Read_Sscore("Server_Positivity_Score.txt")

    #check user
    if message.author == client.user:
        return

    #check messages from user
    if msg.startswith('$hello'):
        await message.channel.send('Hello! Lets be positive!')
    
    if msg.startswith('$a'):
        await message.channel.send('I am the Positivity Bot, created by BasiliskByte! He thinks the world should be more positive... and I agree! Lets have fun, and be positive!')

    if msg.startswith('$f'):
        await message.channel.send('Features: Swearing Positivity Reminder, Server Positivity Score')
        await message.channel.send('More features coming soon!')

    if msg.startswith('$v'):
        await message.channel.send('Positivity Bot - v1.1.0 - BasiliskByte')

    if msg.startswith('$help'):
        await message.channel.send('Commands:')
        await message.channel.send('$a - About')
        await message.channel.send('$f - Features')
        await message.channel.send('$v - Version')
        await message.channel.send('$help - Help')
        await message.channel.send('$sscore - Server Positivity Score')
        await message.channel.send('$rst_sscore - Server Positivity Score Reset')

    if msg.startswith('$sscore'):
        await message.channel.send('Server Positivity Score: ')
        await message.channel.send(Server_Positivity_Score)
        
    if msg.startswith('$rst_sscore'):
        #write new positivity score to file
        Server_Positivity_Score = 100
        F_Sscore = open('Server_Positivity_Score.txt', 'r+')
        F_Sscore.truncate(0)
        F_Sscore.write(str(Server_Positivity_Score))
        await message.channel.send('Server Positivity Score: ')
        await message.channel.send(Server_Positivity_Score)
   
    #check for bad words in msg
    for word in Bad_Words:
      #filter out commands
      if '$' in msg:
        break
      #if bad word is found
      if word in msg:
        await message.channel.send('Please do not say negative words!')
        #decrease Server_Positivity_Score
        New_Sscore = Server_Positivity_Score - 5
        
        #write new positivity score to file
        F_Sscore = open('Server_Positivity_Score.txt', 'r+')
        F_Sscore.truncate(0)
        F_Sscore.write(str(New_Sscore))

        #printing the word and msg for debugging
        print(word)
        print(msg)
        break
    
keep_alive()
client.run(os.getenv('TOKEN'))