Learning Project: Files and directories in .NET
--------------

This is a project I designed to practice working with files and directories in .NET, using C#.

**Scenario**:
You work for a globally renowned football charity, which raises funds by organising an annual all-star football match played in a different top league each year. Last year the match was played in Spain's LaLiga, and this year it is taking place in the UK's Premier League.

There are 20 teams participating in the event. Each team nominates 2 players. All 40 participating players are split up into two sides who will be playing the charity match.

**Task**:
Your goal is to create a program which will take in all nominees from participating teams, split them up into 2 equal sized teams, and produce a file containing the final line-up for the match. In this exercise, you do not need to worry about teams containing the correct number of players in each position, or the teams being well balanced in terms of playing ability.

Go to the 'CharityMatch' directory. All participating teams have a sub-directory within the 'Participants' directory, and both nominees from each team can be found there. Each team's nominees' names are submitted in individual .json files named 'Nominee1.json' and 'Nominee2.json'.

Your program should create a 'MatchLineUp' sub-directory in the 'CharityMatch' directory, and place a .txt file containing the final match line-up inside of it.

**This exercise is designed to practice the following skills:**
- Work with directories and sub-directories
- Create files
- Read from files
- Write to files
- Parse data in files