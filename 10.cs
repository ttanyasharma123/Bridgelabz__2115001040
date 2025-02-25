import java.io.*;
import java.util.*;


public class CSVFileMerger {
    public static void main(String[] args) {
        String file1 = "students1.csv"; // First CSV file
        String file2 = "students2.csv"; // Second CSV file
        String outputFile = "merged_students.csv"; // Merged output file


        Map<String, String[]> studentData = new HashMap<>();


        try {
            // Read students1.csv (ID, Name, Age)
            BufferedReader br1 = new BufferedReader(new FileReader(file1));
            String line;
            boolean isHeader = true;


            while ((line = br1.readLine()) != null) {
                if (isHeader) { isHeader = false; continue; } // Skip header


                String[] data = line.split(",");
                studentData.put(data[0], new String[]{data[1], data[2]}); // Store Name & Age
            }
            br1.close();


            // Read students2.csv (ID, Marks, Grade) and merge
            BufferedReader br2 = new BufferedReader(new FileReader(file2));
            isHeader = true;


            while ((line = br2.readLine()) != null) {
                if (isHeader) { isHeader = false; continue; } // Skip header


                String[] data = line.split(",");
                if (studentData.containsKey(data[0])) {
                    studentData.put(data[0], new String[]{studentData.get(data[0])[0], studentData.get(data[0])[1], data[1], data[2]});
                }
            }
            br2.close();


            // Write merged data into merged_students.csv
            BufferedWriter writer = new BufferedWriter(new FileWriter(outputFile));
            writer.write("ID,Name,Age,Marks,Grade\n"); // Header


            for (Map.Entry<String, String[]> entry : studentData.entrySet()) {
                String[] values = entry.getValue();
                if (values.length == 4) { // Ensure merged data exists
                    writer.write(entry.getKey() + "," + values[0] + "," + values[1] + "," + values[2] + "," + values[3] + "\n");
                }
            }


            writer.close();
            System.out.println("Merged data successfully saved in 'merged_students.csv'");
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}


