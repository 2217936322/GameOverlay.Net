﻿using System;

namespace GameOverlay.Graphics
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public class D2DScene : IDisposable
    {
        private D2DScene()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="D2DScene" /> class.
        /// </summary>
        /// <param name="device">The renderer.</param>
        public D2DScene(D2DDevice device)
        {
            Device = device ?? throw new ArgumentNullException(nameof(device));
            device.BeginScene();
        }

        /// <summary>
        ///     Gets the renderer.
        /// </summary>
        /// <value>The renderer.</value>
        public D2DDevice Device { get; }

        /// <summary>
        ///     Finalizes an instance of the <see cref="D2DScene" /> class.
        /// </summary>
        ~D2DScene()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="D2DScene" /> to <see cref="D2DDevice" />.
        /// </summary>
        /// <param name="scene">The scene.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator D2DDevice(D2DScene scene)
        {
            if (scene.Device == null) throw new InvalidOperationException(nameof(scene.Device) + " is null");

            return scene.Device;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "{D2DScene}";
        }

        #region IDisposable Support

        /// <summary>
        ///     The disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
            }

            Device.EndScene();

            _disposedValue = true;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        #endregion IDisposable Support
    }
}