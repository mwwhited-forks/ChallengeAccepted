
DEL *.class
DEL *.jar

REM -verbose
javac *.java 

jar --create --verbose --manifest=CaesarCipher.mf --file=CaesarCipher.jar *.class

java -jar CaesarCipher.jar