
DEL *.class
DEL *.jar

REM -verbose
javac *.java 

jar --create --verbose --manifest=MorseCode.mf --file=MorseCode.jar *.class

java -jar MorseCode.jar