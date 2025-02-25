public class Student {
    private int id;
    private String name;
    private int age;
    private double marks;


    // Constructor
    public Student(int id, String name, int age, double marks) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.marks = marks;
    }


    // Override toString() to display student details
    @Override
    public String toString() {
        return "ID: " + id + ", Name: " + name + ", Age: " + age + ", Marks: " + marks;
    }
}


Main Program 






import java.io.*;
import java.util.*;


public class CSVToStudent {
    public static void main(String[] args) {
        String filePath = "students.csv"; // CSV file location
        List<Student> studentList = new ArrayList<>();


        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {
            String line;
            boolean isHeader = true;


            while ((line = br.readLine()) != null) {
                if (isHeader) {  // Skip the header row
                    isHeader = false;
                    continue;
                }


                String[] data = line.split(",");
                int id = Integer.parseInt(data[0].trim());
                String name = data[1].trim();
                int age = Integer.parseInt(data[2].trim());
                double marks = Double.parseDouble(data[3].trim());


                // Create Student object and add to list
                studentList.add(new Student(id, name, age, marks));
            }
        } catch (FileNotFoundException e) {
            System.out.println("Error: File not found.");
        } catch (IOException e) {
            System.out.println("Error reading file.");
        } catch (Exception e) {
            System.out.println("Invalid data format: " + e.getMessage());
        }


        // Print all students
        System.out.println("Student List:");
        for (Student student : studentList) {
            System.out.println(student);
        }
    }
}








