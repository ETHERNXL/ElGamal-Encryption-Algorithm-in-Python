import random

fopen = open('read.txt','r')
p = int(fopen.readline())
a = int(fopen.readline(2))
x = int(fopen.readline(3))
fopen.close

m = int(input('Введіть число m (Дата народження ММД): '))

b = a ** x % p

y = random.randint(1, p - 1)

e = a ** y % p

k = (m * b ** y) % p

# результат шифрування
wf = open('out.txt','w', encoding='utf-8')
wf.write("Зашифроване повідомлення: " + str(e) + " " + str(k))

# дешифрування
decript = int(k) * pow(int(e), p - 1 - x) % p
wf.write("\nРозшифроване повідомлення: " + str(decript))
wf.close

input()
