def Avg(array):
    if len(array) == 0:
        return 0
    sum = 0
    for num in array:
        sum += num
    average = sum / len(array)
    return average

def main():
    # Declare and initialize an array with proper values
    num = int(input("Enter the number of elements: "))
    numarray = []
    
    while num < 5:
        print("Type in at least 5 numbers!!")
        num = int(input("Enter the number of elements: "))
    
    print("Enter {} numbers: ".format(num))
    for i in range(int(num)):
        numarray.append(float(input()))
        
    # Print the average of all the elements in the array
    avg = float(Avg(numarray))
    print("The average is: ", round(float(avg), 2))

    # Check if the average is double digits, single digits, or negative
    if avg > 0:
        print("Positive")
        if avg >= 10:
            print("Double digits")
        else:
            print("Single digits")
    elif avg == 0:
        print("Zero")
    else:
        print("Negative")
        if avg <= -10:
            print("Double digits")
        else:
            print("Single digits")

# Call the main function
if __name__ == '__main__':
    main()