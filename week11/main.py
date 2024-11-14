from Clock import Clock

def main():
    
    clock = Clock()
    i = 0
  
    for i in range(0, 86400):
        clock.Tick()
        print(clock.Time)
        i += 1

if __name__ == "__main__":
    main()