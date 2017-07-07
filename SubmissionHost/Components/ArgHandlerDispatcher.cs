namespace BITOJ.SubmissionHost.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// 管理命令行选项处理器链。
    /// </summary>
    internal sealed class ArgHandlerDispatcher
    {
        private List<IArgHandler> m_handlers;

        /// <summary>
        /// 初始化 ArgHandlerDispatcher 类的新实例。
        /// </summary>
        public ArgHandlerDispatcher()
        {
            m_handlers = new List<IArgHandler>();
        }

        /// <summary>
        /// 将当前的命令行处理上下文指派到特定的处理器。
        /// </summary>
        /// <param name="context">要指派的命令行处理上下文。</param>
        /// <returns>一个值，该值指示是否找到了匹配的指派。</returns>
        /// <exception cref="ArgumentNullException"/>
        public bool Dispatch(ArgContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (IArgHandler handler in m_handlers)
            {
                if (handler.Accept(context.Next))
                {
                    handler.Resolve(context);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 从指定的程序集中加载所有的命令行选项处理器。
        /// </summary>
        /// <param name="assmbly">命令行选项处理器容器程序集。</param>
        /// <exception cref="ArgumentNullException"/>
        public void LoadArgHandlers(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            foreach (Type t in assembly.GetTypes())
            {
                foreach (Type inter in t.GetInterfaces())
                {
                    if (inter == typeof(IArgHandler))
                    {
                        m_handlers.Add((IArgHandler)Activator.CreateInstance(t));
                    }
                }
            }
        }
    }
}
