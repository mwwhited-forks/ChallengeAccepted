namespace CardiacComputer.Cli;

public record Instruction(Opcodes Opcode, int Operand)
{
    public static implicit operator int(Instruction instruction) =>
        (int)instruction.Opcode * 100 + instruction.Operand % 100;

    public static implicit operator Instruction(int code) =>
        new((Opcodes)(code / 100), code % 100);

    public static implicit operator Instruction((Opcodes Opcode, int Operand) instruction) =>
        new(instruction.Opcode, instruction.Operand);

    public override string ToString() => $"{Opcode} {Operand:00}";
}
