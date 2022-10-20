# ConvertXmlToCsv
This project contains the solution for Haiying Lou's coding assessment for GenTrack.

1,what was done
(1)Read elements from XML file.
	- The path of input XML file: 
	ConvertXmlToCsv\ConvertXmlToCsv\inputXMLfile\testfile.xml
	
(2)Extract out CSVIntervalData from XML file

(3)Create seperate CSV file for each block of data which starts with 200.
	- Leading and trailing white spaces, tabs, additional newlines are removed.
	- The name of each generated csv file is the second field in the "200" row.
	- The path of generated csv files:
	ConvertXmlToCsv\ConvertXmlToCsv\outputCSVFile
	
(4)CSV will display data as follow format:
	row starting with 100
	row starting with 200
	rows starting with 300
	row starting with 900

(5)validation rules for CSVIntervalData as below:
	- Rows within the CSVIntervalData element can only start with "100", "200", "300","900"
	- CSVIntervalData should have the "100" row as a header, and the "900" row as the trailer.
	- "100", "900" rows should only appear once inside the CSVIntervalData element.
	- The CSVIntervalData element can only start with "100", "200", "300","900".
	- "200" and "300" can repeat and will be within the header and trailer rows.
	- "200" row must be followed by at least 1 "300" row. 
	 
(6)Unit test, 11 unit test case
	Mock input XML files (11 cases) which are placed in path of ConvertXmlToCsv\XmlToCsvUnitTest\TestData
	All cases pass
	
2,what wasn't done
	No
	
3,what would be done with more time
	- More unit test cases to cover more or all branches in code.
	- Add more mock data to simulate more illegal CSVIntervalData
	- Test cases about read XML file and write CSV files:
		1)In function getCSVIntervalDataFromXml
		- xmlFilePath is null
		- xmlFilePath points to an inexisting xml
		- xmlFilePath points to a xml but its contents are invalid
		2)In function writeDataToCsv
		- the path pointed by outputCSVFilePath may be invalid