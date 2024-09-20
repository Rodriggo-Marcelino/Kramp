namespace Domain.Entity.Enum;

public enum Period
{
    DAILY = 1,
    WEEKLY = 2,

    /*
     * Variáveis JUMP
     * Permitem ao criador do treino programar quantos dias de descanso até
     * repetir o treino
     * JUMP_ONE_DAY pula 1 dia (Treino Segunda, Pula Terça, Repete Quarta)
     * JUMP_TWO_DAYS pula 2 dias (Treino Segunda, Pula Terça, Pula Quarta, Repete Quinta)
     * JUMP_THREE_DAYS pula 3 dias (Treino Segunda, Pula Terça, Pula Quarta, Pula Quinta, Repete Sexta)
     */
    JUMP_ONE_DAY = 3,
    JUMP_TWO_DAYS = 4,
    JUMP_THREE_DAYS = 5,

}