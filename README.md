![An origami image](https://github.com/soundarmoorthy/origami/blob/master/origami.jpg?raw=true&sanitize=true)

### Summary
Origami is a .NET Core console application that will convert a hierarchial json file from the azure database migration tool, to a flatterned excel file.



### Why Origami
Origami is a data warehousing tool for the data genereated by the Microsoft [Data Migration Assistant (DMA)](https://docs.microsoft.com/en-us/sql/dma/dma-overview?view=sql-server-ver15) tool. This tool is used to analyze on-prem SQL Server databases and produce a report that will show the list of incompatibilities / warnings when migrating them to the cloud. Unfortunately the tool produces a json file that is not very helpful in socializing the output, slice and dice and play around. Origimai takes this json file as input and produces a flatterned excel file that has all the data as columns by introducing redundancy. Once converted it's easy to answer some of the following questions easily
* How many unique migration blockers do we have 
* Which database has the most number of issues 
* What is count of issues for a given database
* What is the level of effort if we choose a specific target compatibility level 

and more. Origami doesn't modify any data in the json. It just converts the hierarchial nature of it to flatterned nature. 

### Prerequisities
Note : This is only for building and development. If you are downloading the binaries from releases section, you won't need it.
* .NET Core 3.1 runtime
* Micorsoft Excel (For viewing the output produced from the tool)

### How to download and use it 
* Goto the releases page. Download the zip file for the operating system of choice.
* Once downloaded from the root folder run as follows 
```
./Origami -i <Path_To_Input_File> -o <Path_to_Output_File>
```

### How to build and use it
* Download the repository. 
* Build it 
```
dotnet build
```
* Run as follows. Make sure input is a valid json file and the output is a valid xlsx extension
```
dotnet Origami/bin/Debug/netcoreapp3.1/Origami.dll -i <Path_To_Input_File> -o <Path_to_Output_File>
```

* For more information run the help command as follows
```
dotnet Origami/bin/Debug/netcoreapp3.1/Origami.dll --help
Origami 1.0.0
Copyright (C) 2020 Origami

  -i, --input_json_file     Required. Input json file that is generated from the database migration assistant

  -o, --output_xlsx_file    Required. Output file that will be generated based on the input json file. Make sure you have access to the
                            specified path and that it's writable

  --help                    Display this help screen.

  --version                 Display version information.
```
