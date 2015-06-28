using Gengine.Input;

namespace Gengine.Animation {
    public interface IAnimationMapper {
        string GetAnimationId(InputComponent input);
    }
}
